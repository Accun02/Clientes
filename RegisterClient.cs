using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLine
{
    public class RegisterClient
    {
        private Dictionary<int, Customer> registerCustomer;
        public Dictionary<int, Customer> RegisterCustomer => registerCustomer;

        // Registry Steps
        private StepEnterID stepEnterID;
        private StepEnterName stepEnterName;
        private StepEnterSurname stepEnterSurname;
        private StepEnterPhone stepEnterPhone;
        private StepEnterExpenses stepEnterExpenses;
        private StepEnterPurchases stepEnterPurchases;
        private StepEndRegister stepEndRegister;

        // Registry Steps getter setter
        public StepEnterID StepEnterID => stepEnterID;
        public StepEnterName StepEnterName => stepEnterName;
        public StepEnterSurname StepEnterSurname => stepEnterSurname;
        public StepEnterPhone StepEnterPhone => stepEnterPhone;
        public StepEnterExpenses StepEnterExpenses => stepEnterExpenses;
        public StepEnterPurchases StepEnterPurchases => stepEnterPurchases;
        public StepEndRegister StepEndRegister => stepEndRegister;

        //Constructor
        public RegisterClient(Dictionary <int,Customer> registerCustomer)
        {
            this.registerCustomer = registerCustomer;

            stepEnterID = new StepEnterID(this);
            stepEnterName = new StepEnterName(this);
            stepEnterSurname = new StepEnterSurname(this);
            stepEnterPhone = new StepEnterPhone(this);
            stepEnterExpenses = new StepEnterExpenses(this);
            stepEnterPurchases = new StepEnterPurchases(this);
            stepEndRegister = new StepEndRegister(this);

            currentStep = stepEnterID;
        }

        private bool enterACustomer = false;
        public bool EnterACustomer { get { return enterACustomer; } set { enterACustomer = value; } }

        private IRegistrySteps currentStep;
        public IRegistrySteps CurrentStep { get { return currentStep; } set { currentStep = value; } }

        private Customer? customer;
        public Customer? Customer { get { return customer; }  set { customer = value; } }

        private bool customerAccesed;
        public bool CustomerAccesed { get { return customerAccesed; } set { customerAccesed = value; }  }

        public int Id;
        public string? Name = null;
        public string? Surname = null;
        public string? PhoneNumber = null;
        public float Spending;
        public int Purchases = 0;

        public void ChangeStep(IRegistrySteps newStep) 
        {
            currentStep = newStep;
        }

        public void InsertClient() // Agregar un cliente nuevo o viejo
        {
            enterACustomer = false;
            currentStep = stepEnterID;

            while (!enterACustomer)
            {
                currentStep.RunUpdate();
            }
        }
    }
}
