using System;
using System.Collections.Generic;
using System.Linq;
using yogaAshram.Models;

namespace yogaAshram.Services
{
    
    public class ClientServices
    {
        private readonly YogaAshramContext _db;

        public ClientServices(YogaAshramContext db)
        {
            _db = db;
        }

        public List<DateTime> DatesForAttendance(DateTime firstTime, long groupId, int attendanceDays)
        {
            List<CalendarEvent> calendarEvents = _db.CalendarEvents.Where(c => c.GroupId == groupId).ToList();
            DayOfWeek[] dayOfWeeks = new DayOfWeek[calendarEvents.Count];
            for (int i = 0; i < calendarEvents.Count; i++)
            {
                dayOfWeeks[i] = calendarEvents[i].DayOfWeek;
            }
            
            DateTime days;
            if(dayOfWeeks.Length == 3)
                days = firstTime.AddDays(40);
            else if(dayOfWeeks.Length == 2) 
                days = firstTime.AddDays(50);
            else
                days = firstTime.AddDays(90);
            
            List<DateTime> dates = Enumerable.Range(0,  days.Subtract(firstTime).Days)
                .Select(offset => firstTime.AddDays(offset))
                .Where(d => dayOfWeeks.Contains(d.DayOfWeek))
                .ToList();
            
            DateTime [] dateTimes = new DateTime[attendanceDays];
            for (int i = 0; i < attendanceDays; i++)
            {
                dateTimes[i] = dates[i];
            }
            
            return dateTimes.ToList();
        }
        public DateTime EndDateForClientsMembership(DateTime firstTime, long groupId, int attendanceDays)
        {
            List<CalendarEvent> calendarEvents = _db.CalendarEvents.Where(c => c.GroupId == groupId).ToList();
            DayOfWeek[] dayOfWeeks = new DayOfWeek[calendarEvents.Count];
            for (int i = 0; i < calendarEvents.Count; i++)
            {
                dayOfWeeks[i] = calendarEvents[i].DayOfWeek;
            }
            
            DateTime days;
            if(dayOfWeeks.Length == 3)
                days = firstTime.AddDays(40);
            else if(dayOfWeeks.Length == 2) 
                days = firstTime.AddDays(50);
            else
                days = firstTime.AddDays(90);
            
            List<DateTime> dates = Enumerable.Range(0,  days.Subtract(firstTime).Days)
                .Select(offset => firstTime.AddDays(offset))
                .Where(d => dayOfWeeks.Contains(d.DayOfWeek))
                .ToList();
            
            DateTime [] dateTimes = new DateTime[attendanceDays];
            for (int i = 0; i < attendanceDays; i++)
            {
                dateTimes[i] = dates[i];
            }
            return dateTimes[^1];
        }
        public DateTime DateIfFrozen(DateTime lastDay, long groupId)
        {
            List<CalendarEvent> calendarEvents = _db.CalendarEvents.Where(c => c.GroupId == groupId).ToList();
            DayOfWeek[] dayOfWeeks = new DayOfWeek[calendarEvents.Count];
            for (int i = 0; i < calendarEvents.Count; i++)
            {
                dayOfWeeks[i] = calendarEvents[i].DayOfWeek;
            }
            
            DateTime days = lastDay.AddDays(10);
           
            
            List<DateTime> dates = Enumerable.Range(0,  days.Subtract(lastDay).Days)
                .Select(offset => lastDay.AddDays(offset))
                .Where(d => dayOfWeeks.Contains(d.DayOfWeek))
                .ToList();
            
            DateTime [] dateTimes = new DateTime[2];
            for (int i = 0; i < 2; i++)
            {
                dateTimes[i] = dates[i];
            }
            return dateTimes[^1];
        }
        public List<DateTime> TwoTimesTrial(long? groupId, DateTime firstTime)
        {
            List<CalendarEvent> calendarEvents = _db.CalendarEvents.Where(c => c.GroupId == groupId).ToList();
            DayOfWeek[] dayOfWeeks = new DayOfWeek[calendarEvents.Count];
            for (int i = 0; i < calendarEvents.Count; i++)
            {
                dayOfWeeks[i] = calendarEvents[i].DayOfWeek;
            }
            DateTime tenDays = firstTime.AddDays(10);
            
            List<DateTime> dates = Enumerable.Range(0, 1 + tenDays.Subtract(firstTime).Days)
                .Select(offset => firstTime.AddDays(offset))
                .Where(d => dayOfWeeks.Contains(d.DayOfWeek))
                .ToList();
            
            DateTime [] dateTimes = new DateTime[2];
    
            dateTimes[0] = dates[1];
            dateTimes[1] = dates[2];

            return dateTimes.ToList();
        }
    }
}