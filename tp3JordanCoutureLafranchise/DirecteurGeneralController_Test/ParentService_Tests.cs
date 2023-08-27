using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2JordanCoutureLafranchise.Models;
using tp2JordanCoutureLafranchise.Models.Data;
using tp3JordanCoutureLafranchise.Services;

namespace Tests
{
    public class ParentService_Tests
    {

        private ILogger<HockeyRebelsDBContext> _ilogger;
        private IParentService parentService;
        private DbContextOptions<HockeyRebelsDBContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<HockeyRebelsDBContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options);
            return options;
        }

        private void SeedInMemoryStore(DbContextOptions<HockeyRebelsDBContext> options)
        {

            using (var context = new HockeyRebelsDBContext(options, _ilogger))
            {
                if (!context.Parents.Any())
                {
                    context.Parents.Add(new tp2JordanCoutureLafranchise.Models.Parent {ParentId=1, Description = "dsadsa", ImageURL = "dsadsadsa", Nom = "allo" });
                    context.Parents.Add(new tp2JordanCoutureLafranchise.Models.Parent { ParentId=2,Description = "fgfgdsa", ImageURL = "dsahgjda", Nom = "george" });

                    context.SaveChanges();
                }


            }
        }


        [Fact]
        public async Task CreateParentReturnNbParents()
        {
            // En utilisant la BD en mémoire avec un nom unique 
            using (var context = new HockeyRebelsDBContext(SetUpInMemory("CreateParentReturnNbEnfants"), _ilogger))
            {

                // Arrange
                // Intancier le service 
                IParentService parentService = new ParentService(context);


                //act
                var count = context.Parents.Count();
                //assert 
                Assert.Equal(2, count);


            }

        }

        [Fact]
        public async Task DeleteParentReturnNbParents()
        {
            using (var context = new HockeyRebelsDBContext(SetUpInMemory("DeleteParentReturnNbParents"), _ilogger))
            {
                // Arrange
                var parent = context.Parents.Where(x => x.Nom == "allo").Single();

                // Intancier le service 
                IParentService parentService = new ParentService(context);


                //act
                parentService.DeleteAsync(parent.ParentId);
                var count = context.Parents.Count();
                //assert 
                Assert.Equal(1, count);
                
            }
        }

        [Fact]
        public async Task GetByIdAsyncReturnNomParent()
        {
            using (var context = new HockeyRebelsDBContext(SetUpInMemory("GetByIdAsyncReturnNomParent"), _ilogger))
            {
                // Arrange

                var expectedparent = context.Parents.Where(x => x.ParentId == 1).Single();
                var expectedparentNom = expectedparent.Nom;
                // Intancier le service 
                IParentService parentService = new ParentService(context);


                //act
                var result = await parentService.GetByIdAsync(1);

                //assert 
                Assert.NotNull(result);
                Assert.Same(expectedparentNom, result.Nom);
            }
        }

     


        [Fact]
        public async Task EditCheckReturnNom()
        {
            // Arrange
            using (var context = new HockeyRebelsDBContext(SetUpInMemory("EditCheckReturnNom"), _ilogger))
            {

       

                var parentData = new List<Parent>
    {
        new Parent { ParentId = 1, Nom = "Parent 1" ,Description="allo",ImageURL="photo"}
    };


                IParentService parentService = new ParentService(context);

                var updatedEntity = new Parent { ParentId = 1, Nom = "Updated Parent 1", Description = "allo", ImageURL = "photo" };

                // Act
                await parentService.EditAsync(updatedEntity);

                // Assert
                var retrievedEntity = context.Parents.FirstOrDefault(e => e.ParentId == 1);
                Assert.NotNull(retrievedEntity);
                Assert.Equal("Updated Parent 1", retrievedEntity?.Nom);
            }
        }


    }
}
