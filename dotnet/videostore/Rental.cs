namespace videostore
{
    class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return daysRented;
        }

        public Movie GetMovie()
        {
            return movie;
        }

        private Movie movie;
        private int daysRented;
    }
}