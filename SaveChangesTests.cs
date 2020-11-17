using System.Linq;
using System.Threading.Tasks;
using Xunit;

//[assembly: CollectionBehavior(DisableTestParallelization = true)] // tests pass
[assembly: CollectionBehavior(MaxParallelThreads = 2)] // tests fail

namespace SaveChangesAsyncTests
{
    public class SaveChangesAsyncTests
    {
        [Fact]
        public async Task SaveChangesAsync_Fails()
        {
            int aId;

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

                await ctx.SaveChangesAsync(); // tests fail, but they pass with this commented out

                ctx.AEntities.Remove(a);
                ctx.SaveChanges();
            }

            using (var ctx = new DemoContext())
            {
                var queriedEntity = ctx.AEntities.SingleOrDefault(e => e.Id == aId);
                Assert.Null(queriedEntity);
            }
        }
    }

    public class F000 : SaveChangesAsyncTests { }
    public class F001 : SaveChangesAsyncTests { }
    public class F002 : SaveChangesAsyncTests { }
    public class F003 : SaveChangesAsyncTests { }
    public class F004 : SaveChangesAsyncTests { }
    public class F005 : SaveChangesAsyncTests { }
    public class F006 : SaveChangesAsyncTests { }
    public class F007 : SaveChangesAsyncTests { }
    public class F008 : SaveChangesAsyncTests { }
    public class F009 : SaveChangesAsyncTests { }
    public class F010 : SaveChangesAsyncTests { }
    public class F011 : SaveChangesAsyncTests { }
    public class F012 : SaveChangesAsyncTests { }
    public class F013 : SaveChangesAsyncTests { }
    public class F014 : SaveChangesAsyncTests { }
    public class F015 : SaveChangesAsyncTests { }
    public class F016 : SaveChangesAsyncTests { }
    public class F017 : SaveChangesAsyncTests { }
    public class F018 : SaveChangesAsyncTests { }
    public class F019 : SaveChangesAsyncTests { }
    public class F020 : SaveChangesAsyncTests { }
    public class F021 : SaveChangesAsyncTests { }
    public class F022 : SaveChangesAsyncTests { }
    public class F023 : SaveChangesAsyncTests { }
    public class F024 : SaveChangesAsyncTests { }
    public class F025 : SaveChangesAsyncTests { }
    public class F026 : SaveChangesAsyncTests { }
    public class F027 : SaveChangesAsyncTests { }
    public class F028 : SaveChangesAsyncTests { }
    public class F029 : SaveChangesAsyncTests { }
    public class F030 : SaveChangesAsyncTests { }
    public class F031 : SaveChangesAsyncTests { }
    public class F032 : SaveChangesAsyncTests { }
    public class F033 : SaveChangesAsyncTests { }
    public class F034 : SaveChangesAsyncTests { }
    public class F035 : SaveChangesAsyncTests { }
    public class F036 : SaveChangesAsyncTests { }
    public class F037 : SaveChangesAsyncTests { }
    public class F038 : SaveChangesAsyncTests { }
    public class F039 : SaveChangesAsyncTests { }
    public class F040 : SaveChangesAsyncTests { }
    public class F041 : SaveChangesAsyncTests { }
    public class F042 : SaveChangesAsyncTests { }
    public class F043 : SaveChangesAsyncTests { }
    public class F044 : SaveChangesAsyncTests { }
    public class F045 : SaveChangesAsyncTests { }
    public class F046 : SaveChangesAsyncTests { }
    public class F047 : SaveChangesAsyncTests { }
    public class F048 : SaveChangesAsyncTests { }
    public class F049 : SaveChangesAsyncTests { }
    public class F050 : SaveChangesAsyncTests { }
    public class F051 : SaveChangesAsyncTests { }
    public class F052 : SaveChangesAsyncTests { }
    public class F053 : SaveChangesAsyncTests { }
    public class F054 : SaveChangesAsyncTests { }
    public class F055 : SaveChangesAsyncTests { }
    public class F056 : SaveChangesAsyncTests { }
    public class F057 : SaveChangesAsyncTests { }
    public class F058 : SaveChangesAsyncTests { }
    public class F059 : SaveChangesAsyncTests { }
    public class F060 : SaveChangesAsyncTests { }
    public class F061 : SaveChangesAsyncTests { }
    public class F062 : SaveChangesAsyncTests { }
    public class F063 : SaveChangesAsyncTests { }
    public class F064 : SaveChangesAsyncTests { }
    public class F065 : SaveChangesAsyncTests { }
    public class F066 : SaveChangesAsyncTests { }
    public class F067 : SaveChangesAsyncTests { }
    public class F068 : SaveChangesAsyncTests { }
    public class F069 : SaveChangesAsyncTests { }
    public class F070 : SaveChangesAsyncTests { }
    public class F071 : SaveChangesAsyncTests { }
    public class F072 : SaveChangesAsyncTests { }
    public class F073 : SaveChangesAsyncTests { }
    public class F074 : SaveChangesAsyncTests { }
    public class F075 : SaveChangesAsyncTests { }
    public class F076 : SaveChangesAsyncTests { }
    public class F077 : SaveChangesAsyncTests { }
    public class F078 : SaveChangesAsyncTests { }
    public class F079 : SaveChangesAsyncTests { }
    public class F080 : SaveChangesAsyncTests { }
    public class F081 : SaveChangesAsyncTests { }
    public class F082 : SaveChangesAsyncTests { }
    public class F083 : SaveChangesAsyncTests { }
    public class F084 : SaveChangesAsyncTests { }
    public class F085 : SaveChangesAsyncTests { }
    public class F086 : SaveChangesAsyncTests { }
    public class F087 : SaveChangesAsyncTests { }
    public class F088 : SaveChangesAsyncTests { }
    public class F089 : SaveChangesAsyncTests { }
    public class F090 : SaveChangesAsyncTests { }
    public class F091 : SaveChangesAsyncTests { }
    public class F092 : SaveChangesAsyncTests { }
    public class F093 : SaveChangesAsyncTests { }
    public class F094 : SaveChangesAsyncTests { }
    public class F095 : SaveChangesAsyncTests { }
    public class F096 : SaveChangesAsyncTests { }
    public class F097 : SaveChangesAsyncTests { }
    public class F098 : SaveChangesAsyncTests { }
    public class F099 : SaveChangesAsyncTests { }
    public class F100 : SaveChangesAsyncTests { }
    public class F101 : SaveChangesAsyncTests { }
    public class F102 : SaveChangesAsyncTests { }
    public class F103 : SaveChangesAsyncTests { }
    public class F104 : SaveChangesAsyncTests { }
    public class F105 : SaveChangesAsyncTests { }
    public class F106 : SaveChangesAsyncTests { }
    public class F107 : SaveChangesAsyncTests { }
    public class F108 : SaveChangesAsyncTests { }
    public class F109 : SaveChangesAsyncTests { }
    public class F110 : SaveChangesAsyncTests { }
    public class F111 : SaveChangesAsyncTests { }
    public class F112 : SaveChangesAsyncTests { }
    public class F113 : SaveChangesAsyncTests { }
    public class F114 : SaveChangesAsyncTests { }
    public class F115 : SaveChangesAsyncTests { }
    public class F116 : SaveChangesAsyncTests { }
    public class F117 : SaveChangesAsyncTests { }
    public class F118 : SaveChangesAsyncTests { }
    public class F119 : SaveChangesAsyncTests { }
    public class F120 : SaveChangesAsyncTests { }
    public class F121 : SaveChangesAsyncTests { }
    public class F122 : SaveChangesAsyncTests { }
    public class F123 : SaveChangesAsyncTests { }
    public class F124 : SaveChangesAsyncTests { }
    public class F125 : SaveChangesAsyncTests { }
    public class F126 : SaveChangesAsyncTests { }
    public class F127 : SaveChangesAsyncTests { }
    public class F128 : SaveChangesAsyncTests { }
    public class F129 : SaveChangesAsyncTests { }
}
