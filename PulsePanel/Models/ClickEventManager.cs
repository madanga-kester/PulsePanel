namespace PulsePanel.Models
{
    // Click Event Manager class for managing and storing multiple clicks
    public class ClickEventManager
    {
        private readonly List<ClickEvents> _clickHistory = new List<ClickEvents>();


        private readonly object _lock = new();// preventing race/ data corruption if multiple users click things at the same time.

        // Adding a new click event 
        public void AddClick(string elementId, string pageUrl, string userId, string IpAddress, string UserDevice, string PreviousPageUrl)
        {
            var click = new ClickEvents(elementId, pageUrl, userId, IpAddress, UserDevice, PreviousPageUrl);
            lock (_lock)
            {
                _clickHistory.Add(click);
            }
        }

        // gett all clicks for a given user
        public List<ClickEvents> UserClicks(string userId)
        {
            lock (_lock)
            {
                return _clickHistory.FindAll(c => c.UserId == userId);
            }
        }

        //Get all stored clicks

        public List<ClickEvents> AllClicks()
        {
            lock (_lock)
            {
                return _clickHistory.ToList();
            }
        }

        // count the total clicks a user made 
        public int SpecificUserClickCount(string userId)
        {
            lock (_lock)
            {
                return _clickHistory.Count(c => c.UserId == userId);
            }
        }


        // getting clicks that happened on a specific page
        public List<ClickEvents> PageClicks(string pageUrl)
        {
            lock (_lock)
            {
                return _clickHistory.FindAll(c => c.PageUrl == pageUrl);
            }
        }


        // get most clicked elements
        public List<string> MostClickedElements(int topN)
        {
            lock (_lock)
            {
                return _clickHistory
                    .GroupBy(c => c.ElementId)
                    .OrderByDescending(g => g.Count())
                    .Take(topN)
                    .Select(g => g.Key)
                    .ToList();
            }
        }


        // rmoving clicks that are older than N days
        public List<string> DeleteOldClicks(int Ndays)
        {
            lock (_lock)
            {
                DateTime threshold = DateTime.UtcNow.AddDays(-Ndays);
                var oldClicks = _clickHistory.Where(c => c.Timestamp < threshold).ToList();
                _clickHistory.RemoveAll(c => c.Timestamp < threshold);
                return oldClicks.Select(c => c.UserId).Distinct().ToList();
            }
        }

        public void DeleteAllClicks()
        {
            _clickHistory.Clear();
        }


    }
}
