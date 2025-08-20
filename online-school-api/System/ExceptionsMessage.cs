namespace online_school_api.system
{
    public class ExceptionsMessage
    {
        //student exceptions
        public const string StudentAlreadyExistsExcpt = "The Student already exist";

        public const string StudentNotFoundException = "The Student doesn't exist";

        //book exceptions
        public const string BookNotFoundException = "The book doesn't exist";

        public const string BookAlreadyExistException = "The Book already exist";

        //course exceptions

        public const string CourseAlreadyExistException = "The Course already exist";

        public const string CourseNotFoundException = "The Course doesn't exist";


        //enrolments exceptions

        public const string EnrolmentsNotFound = "We don't have Enrolment, Create it!";






    }
}
