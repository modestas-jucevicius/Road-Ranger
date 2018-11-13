using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRangerBackEnd.Score
{
    [Serializable()]    //Objektas gali buti konvertuotas i stream of bytes, kad po to galetu
                        //buti issaugotas (pvz duombazej)
    public class NotEnoughScorePointsException : System.Exception
    {
        public NotEnoughScorePointsException() : base() { }
        public NotEnoughScorePointsException(string message) : base(message) { }
        public NotEnoughScorePointsException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected NotEnoughScorePointsException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
