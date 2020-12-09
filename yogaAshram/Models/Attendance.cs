using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace yogaAshram.Models
{
    public enum AttendanceState
    {
         [Description("+")]
        attended=1,
        [Description("н")]
      
        notattended=2,
        [Description("з")]
        frozen=3,
        [Description("#")]
        notcheked=4,
        [Description("c")]
        cancel =5
    }
    public class Attendance
    {
        public long Id { get; set; }
        
        public long  ClientId  { get; set; }
        public virtual Client  Client { get; set; }
        public long  GroupId  { get; set; }
        public virtual Group  Group { get; set; }
        public long? MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
        public long? ClientsMembershipId { get; set; }
        public virtual  ClientsMembership ClientsMembership{ get; set; }
        public AttendanceState AttendanceState { get; set; } = Models.AttendanceState.notcheked;
        public bool IsChecked { get; set; } = false;
        public bool IsNotActive { get; set; }
        public DateTime Date { get; set; }
        public long? AttendanceCountId { get; set; }
        public virtual AttendanceCount AttendanceCount { get; set; }

        public string GetColor()
        {
            string res = "";
            if (this.AttendanceState == AttendanceState.notattended)
                res = "#d65050";
            else if (this.AttendanceState == AttendanceState.attended)
                res = "#4ec953";
            else if (this.AttendanceState == AttendanceState.frozen)
                res = "#55b5e2";
            
            else if (this.AttendanceState == AttendanceState.notcheked)
                res = "#dadada";
            else if (this.AttendanceState == AttendanceState.cancel)
                res = "#8657fdf7";
            return res;
        }
    }
}