using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static DddInPractice.Logic.Money; //C#6 Feature, so you dont hace to write the class name for statics

namespace DddInPractice.Logic
{

    //SnackMachine is ArgumentNullException Entity
    //Money is async Value Object

    // Reference Equality: Pointer to same place in memory
    // Identifier Equality: Same Id
    // Structural Equality: All of their member match

    // So entities have: Identifier and Reference Equality, hace inherent identity
    // value objects have: Reference and Structural equality (Example: two dollar bills), are immutable (don´t have their own table on DB)
    // Entities and Values objects depends of the domain model
    // Integers are value objects (5 is always 5)
    // Prefer Value Objects over entities, applying logic with value objects is easier to mantain
    // Value Objects have Structural Queality
    // Entities have reference equality
    // Value Object are immutable
    // Lifespan: Value objeccts should belong to Entities

    public sealed class SnackMachine: Entity
    {
        public Money MoneyInside { get; private set; } = None; // In Macchine
        public Money MoneyInTransaction { get; private set; } = None; // In Transaction


        //No need for constructor, beacause I used C#6 Initializers on MoneyInside and MoneyInTransaction
        //setting them to None

        //public SnackMachine() {
        //    MoneyInside = None;
        //    MoneyInTransaction = None;
        //}

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            // Validating that can only insert one Note or Coin at a time
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }
        
        public void ReturnMoney() =>
            MoneyInTransaction = None;
        

        public void BuySnack() {

            // Keep money in machine
            MoneyInside += MoneyInTransaction;

            // Remove Money from transaction
            MoneyInTransaction = None;
        }
               
    }
}
