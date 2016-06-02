using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UglyTrivia;

namespace Trivia.tests
{
    public class LeJeuDevrait
    {
        [Test]
        public void NUnitIsWorking()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void SeTerminerAprès2BonnesReponsesDUnJoueurQuandIlFaut2PointsPourGagner()
        {
            //Arrange
            var quandIlFaut2PointsPourGagner = 2;
            var le_jeu = new Game(quandIlFaut2PointsPourGagner);
            le_jeu.add("toto");

            //Action
            le_jeu.wasCorrectlyAnswered();
            var seTerminerAprès2BonnesReponsesDUnJoueur = !le_jeu.wasCorrectlyAnswered();

            //Asserts
            Assert.IsTrue(seTerminerAprès2BonnesReponsesDUnJoueur);
        }
    }
}
