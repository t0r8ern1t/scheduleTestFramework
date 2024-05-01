namespace ATframework3demo.TestEntities
{
    public class Group
    {
        public Group()
        {
            title = "Group" + DateTime.Now.Ticks;
        }

        public string title { get; set; }

        public List<Subject> subjects { get; set; } 
    }
}
