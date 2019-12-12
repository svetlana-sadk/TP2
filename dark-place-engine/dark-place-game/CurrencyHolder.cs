using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception {}
    public class CantWithDrawMoreThanCurrentAmountExeption: SystemException{}

    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName {
            get {return currencyName;}
            private set {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount {
            get {return currentAmount;}
            private set {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity {
            get {return capacity;}
            private set {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name,int capacity, int amount) {
           if(name==null || name=="" || amount < 0 ||  name.Length < 4 || name.Length > 10 || name.StartsWith("A") || 
           name.StartsWith("a") || capacity < 1) {
               throw new System.ArgumentException();
           } else {
            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;
           }
        }

        public bool IsEmpty() {
            if(CurrentAmount == 0){
                return true;
            } else {
                return false;
            } 
            
        }

        public bool IsFull() {
            if(Capacity==CurrentAmount){
                return true;
            } else {
                return false;
            }
            
        }

        public void Store(int amount) {
            if(amount<=0){
                throw new System.ArgumentException();
            } 
            if(Capacity<currentAmount+amount){
                throw new NotEnoughtSpaceInCurrencyHolderExeption();
            }
            
            currentAmount+=amount;

        }

        public void Withdraw(int amount) {
            if(amount==0){
                throw new System.ArgumentException();
            }
            if(currentAmount-amount<0){
                throw new CantWithDrawMoreThanCurrentAmountExeption();
            }

            

        }
    }

     

}