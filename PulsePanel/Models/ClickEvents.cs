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

        public string IpAddress { get; set; }      // User's IPa
        public string UserDevice { get; set; }      // Browser/device info

        [Url]
        public string PreviousPageUrl { get; set; }    // Previous page



        // Parameterless constructor for EF Core
        public ClickEvents() { }



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

}






   