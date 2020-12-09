namespace yogaAshram.Models.ModelViews
{
    public enum State
    {
        willAttend=1,
        attended,
        notattended
    }

    public class TrialCheckModel
    { 
        public long Id { get; set; }
             public State State { get; set; }
        public TrialCheckModel(long id, int state)
        {
            Id = id;
            State = (State) state;
        }

       
    }
}