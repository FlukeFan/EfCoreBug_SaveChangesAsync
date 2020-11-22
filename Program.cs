using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaveChangesAsyncTests
{
    static class Program
    {
        // ensure only 2 threads are running at any given time
        private static Semaphore _semaphore = new Semaphore(2, 2);

        static async Task Main(string[] args)
        {
            var skipAwait = args.Length == 1 && args[0].Equals("skipAwait", StringComparison.OrdinalIgnoreCase);

            await Task.WhenAll(Enumerable.Range(0, 150).Select(i => Task.Run(async () =>
            {
                int aId;
                var semaphoreAcquired = false;

                try
                {
                    semaphoreAcquired = _semaphore.WaitOne(TimeSpan.FromSeconds(10));

                    if (!semaphoreAcquired)
                        throw new Exception("Semaphore not acquired");

                    using (var ctx = new DemoContext())
                    {
                        var entityA = ctx.AEntities.Add(new EntityA()).Entity;
                        ctx.SaveChanges();
                        aId = entityA.Id;

                        ctx.BEntities.Add(new EntityB { EntityAId = aId });
                        ctx.SaveChanges();

                        var a = ctx.AEntities.Single(e => e.Id == aId);
                        var bToRemove = ctx.BEntities.Where(e => e.EntityAId == a.Id).ToList();
                        ctx.BEntities.RemoveRange(bToRemove);

                        await Task.CompletedTask;

                        if (!skipAwait)
                            await ctx.SaveChangesAsync(); // passes with this commented out

                        ctx.AEntities.Remove(a);
                        ctx.SaveChanges();
                    }

                    using (var ctx = new DemoContext())
                    {
                        var queriedEntity = ctx.AEntities.SingleOrDefault(e => e.Id == aId);

                        if (queriedEntity != null)
                            throw new Exception("Entity not deleted");
                    }
                }
                finally
                {
                    if (semaphoreAcquired)
                        _semaphore.Release();
                }
            })));

            Console.WriteLine("Success");
        }
    }
}
