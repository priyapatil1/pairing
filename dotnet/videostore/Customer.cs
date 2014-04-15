using System;
using System.Collections;

namespace videostore
{
    class Customer
    {
        public Customer(String name)
        {
            this.name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public String GetName()
        {
            return name;
        }

        public String Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;

            IEnumerator rentalsEnumerator = this.rentals.GetEnumerator();
            String result = "Rental Record for " + GetName() + "\n";

            while (rentalsEnumerator.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental) rentalsEnumerator.Current;

                // determines the amount for each line
                switch (each.GetMovie().GetPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        break;
                }

                frequentRenterPoints++;

                if (each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                        && each.GetDaysRented() > 1)
                    frequentRenterPoints++;

                result += "\t" + each.GetMovie().GetTitle() + "\t" + string.Format("{0:F1}", thisAmount) + "\n";
                totalAmount += thisAmount;

            }

            result += "You owed " + string.Format("{0:F1}", totalAmount) + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points\n";


            return result;
        }


        private String name;
        private ArrayList rentals = new ArrayList();
    }
}