using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public class Notification: BaseObject
    {
        public string Message { get; set; }
        public bool IsSended { get; set; }
        //public ContactId Responsible{get;set;}
    }
}
