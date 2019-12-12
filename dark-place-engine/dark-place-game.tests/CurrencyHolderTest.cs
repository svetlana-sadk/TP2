using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            CurrencyHolder ch1= new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Equal("Brouzouf", ch1.CurrencyName);       
            }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            CurrencyHolder ch2 = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Equal("Dollard", ch2.CurrencyName);
        }

        
        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode Store 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            CurrencyHolder ch3 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 978);
            ch3.Store(10);
            Assert.True(ch3.CurrentAmount == 988);

        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode Store 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () => {
                CurrencyHolder ch4 = new CurrencyHolder("",10 , 5);
                ch4.Store(6);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);

        }
 
        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => {
                CurrencyHolder ch5 = new CurrencyHolder("Abc", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () => {
                CurrencyHolder ch6 = new CurrencyHolder("", 10, 5);
                ch6.Withdraw(6);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        //Un nom de currency doit faire entre 4 et 10 characteres :
        // Ecrivez un test pour un nom de douze caracteres
        public void TestNameBetween4and10(){
            Action mauvaisAppel = () => new CurrencyHolder("Abcdefghijkl",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        //On ne peux pas mettre (methode) put une quantité negative de currency dans un CurrencyHolder
        public void TestCantAddNegativeAmount(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch7 = new CurrencyHolder("",10 , 5);
                ch7.Store(-6);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        //On ne peux pas ajouter ou retirer 0 currency (lever expetion) (2 tests) 
        public void TestAddZeroAmount(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch8 = new CurrencyHolder("",10 , 5);
                ch8.Store(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void TestWithdrawZeroAmount(){
             Action mauvaisAppel = () => {
                CurrencyHolder ch9 = new CurrencyHolder("", 10, 5);
                ch9.Withdraw(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        // Un nom de currency ne doit pas commencer par la lettre a majuscule ou minuscule (2 tests)
        public void TestStartNameWithAMaj(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch10 = new CurrencyHolder("Abcde",EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void TestStartNameWithAMin(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch11 = new CurrencyHolder("abcde",EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        // Un CurrencyHolder ne peux avoir une capacité inférieure à 1 (2 tests)
        public void TestCapacityLessThan1_1(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch12 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 0, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void TestCapacityLessThan1_2(){
            Action mauvaisAppel = () => {
                CurrencyHolder ch13 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, -1, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        // Faire 2 tests unitaires pertinents pour la methode IsEmpty
        public void TestMethodeIsEmpty_1(){
            CurrencyHolder ch14 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            bool res = ch14.IsEmpty();
            Assert.True(res);
        }

        [Fact]
         public void TestMethodeIsEmpty_2(){
            CurrencyHolder ch14 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 5);
            bool res = ch14.IsEmpty();
            Assert.False(res);
        } 

        [Fact]
        // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité (4 test)
        public void TestMethodeIsFull_1(){
            CurrencyHolder ch15 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 5, 5);
            bool res = ch15.IsFull();
            Assert.True(res);
        }

        [Fact]
        public void TestMethodeIsFull_2(){
            CurrencyHolder ch15 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 155, 155);
            bool res = ch15.IsFull();
            Assert.True(res);
        }

        [Fact]
        public void TestMethodeIsFull_3(){
            CurrencyHolder ch15 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 5, 4);
            bool res = ch15.IsFull();
            Assert.False(res);
        }
        [Fact]
        public void TestMethodeIsFull_4(){
            CurrencyHolder ch15 = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 155, 40);
            bool res = ch15.IsFull();
            Assert.False(res);
        }



    }
}