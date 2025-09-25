using System.ComponentModel.DataAnnotations;

namespace PulsePanel.Models
{
    public class ClickEvents
    {
        [Key]
        public int Id { get; set; }                // Unique identifier for each click event

        [Required]
        public string ElementId { get; set; }      // Taking which button or link was clicked

        public DateTime Timestamp { get; set; }    // showing  When it happened

        [Url]
        public string PageUrl { get; set; }        // Where the click happened

        [Required]
        public string UserId { get; set; }         // to identify  the user session
        public string SessionId { get; set; }      // Session identifier

        public string IpAddress { get; set; }      // User's IP
        public string UserDevice { get; set; }      // Browser/device info

        [Url]
        public string PreviousPageUrl { get; set; }    // Previous page





        public ClickEvents(string aElementId, string aPageUrl, string aUserId, string aIpAddress, string aUserDevice, string aPreviousPageUrl)
        {
            ElementId = aElementId;
            PageUrl = aPageUrl;
            UserId = aUserId;
            Timestamp = DateTime.UtcNow;

            IpAddress = aIpAddress;
            UserDevice = aUserDevice;
            PreviousPageUrl = aPreviousPageUrl;


        }

        //methods
        //checking whether the click happened withing the last seconds


        public bool RecentClick(int seconds)
        {
            return (DateTime.UtcNow - Timestamp).TotalSeconds <= seconds;
        }

        public override string ToString()
        {
            return $"[ClickEvents] ElementId: {ElementId}, PageUrl: {PageUrl}, UserId: {UserId}, Timestamp: {Timestamp}, IpAddress: {IpAddress}, UserDevice: {UserDevice}, PreviousPageUrl: {PreviousPageUrl}";
        }
    }




   
    
    
    
    // ClickEventManager class for managing and storing   multiple clicks

public class ClickEventManager
        {
            private readonly List<ClickEvents> _clickHistory = new List<ClickEvents>();
            private readonly object _lock = new ();
        // Adding a new click event
        public void AddClick(string elementId, string pageUrl, string userId, string IpAddress, string UserDevice, string PreviousPageUrl)
            {
                //constructor call 
                var click = new ClickEvents(elementId, pageUrl, userId, IpAddress, UserDevice, UserDevice);
            lock (_lock)
            {
                _clickHistory.Add(click);
            }
        }

        // Getting all clicks for a given user
        public List<ClickEvents> UserClicks(string userId)
        {
            lock (_lock)


            {
                return _clickHistory.FindAll(c => c.UserId == userId);
            }
        }
        // Get all strored clicks

        public List<ClickEvents> AllClicks()

            {
            lock (_lock)
            {
                return _clickHistory.ToList();
            }

        }

        //Counting the total clicks a user made
        public int SpecificUserClickCount(string userId)
{
    lock (_lock)
    {
        return 
    }
}
    }
}