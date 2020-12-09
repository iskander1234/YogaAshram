using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using yogaAshram.Models;

namespace yogaAshram.TagHelpers
{
    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; } 

        public int Year { get; set; }
        
        public List<CalendarEvent> Events { get; set; } 
       

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Attributes.Add("class", "calendar");
            output.Content.SetHtmlContent(GetHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        
        private string GetHtml()
        {
            
            var monthStart = new DateTime(Year, Month, 1);
            var events = Events?.OrderBy(e=>e.TimeStart).GroupBy(e => e.DayOfWeek);
            List<string> dayOfWeek = new List<string>(){"Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье"}; 
            var html = new XDocument(
                new XElement("div",
                    new XAttribute("class", "container-fluid"),
                    new XElement("header",
                        new XElement("h4",
                            new XAttribute("class", "display-4 mb-2 text-center"),
                            monthStart.ToString("MMMM yyyy")
                        ),
                        new XElement("div",
                            new XAttribute("class", "row d-none d-lg-flex p-1 bg-dark text-white"),
                            dayOfWeek.Select(d =>
                                new XElement("h5",
                                    new XAttribute("class", "col-lg p-1 text-center"),
                                    d.ToString()
                                )
                            )
                        )
                    ),
                    new XElement("div",
                        new XAttribute("class", "row border border-right-0 border-bottom-0"),
                        GetDatesHtml()
                    )
                )
            );

            return html.ToString();
            
            string DayOfWeekRus(DayOfWeek dayOfWeekEn)
            {
                switch(dayOfWeekEn)
                {
                    case(DayOfWeek.Sunday):
                        return "Воскресенье";
                    case(DayOfWeek.Monday):
                        return "Понедельник";
                    case(DayOfWeek.Tuesday):
                        return "Вторник";
                    case(DayOfWeek.Wednesday):
                        return "Среда";
                    case(DayOfWeek.Thursday):
                        return "Четверг";
                    case(DayOfWeek.Friday):
                        return "Пятница";
                    case(DayOfWeek.Saturday):
                        return "Суббота";
                }

                return null;
            }
            IEnumerable<XElement> GetDatesHtml()
            {
                
                var startDate = monthStart.AddDays(-(int) monthStart.DayOfWeek);
                
               
                
                var dates = Enumerable.Range(-6, 49).Select(i => startDate.AddDays(i));

                foreach (var d in dates)
                {
                    if (d.DayOfWeek == DayOfWeek.Monday && d != startDate)
                    {
                        yield return new XElement("div",
                            new XAttribute("class", "w-100"),
                            String.Empty
                        );
                    }
                    
                    var mutedClasses = "d-none d-lg-inline-block bg-light text-muted";
                    var currentDay = "currentDay";
                    yield return new XElement("div",
                        new XAttribute("class",
                            $"day col-lg p-2 border border-left-0 border-top-0 text-truncate bg-calendar text-white {(d.Month != monthStart.Month ? mutedClasses : null)} {(d.Date == DateTime.Today ? currentDay : null)}"),
                        new XElement("h5",
                            new XAttribute("class", "row align-items-center"),
                            new XElement("span",
                                new XAttribute("class", "date col-1"),
                                d.Day
                            ),
                    
                            new XElement("small",
                                new XAttribute("class", "col d-lg-none text-center text-muted"),
                                DayOfWeekRus(d.DayOfWeek)
                            ),
                            new XElement("span",
                                new XAttribute("class", "col-1"),
                                String.Empty
                            )
                        ),
                        GetEventHtml(d)
                    );
                }
            }
            
            IEnumerable<XElement> GetEventHtml(DateTime d)
            {
                var hideLink = "invisible";
                return events?.SingleOrDefault(e => e.Key == d.DayOfWeek)?.Select(e =>
                    new XElement("a",
                        new XAttribute("class",
                            $"event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small bg-{e.Type} text-light {(d.Month != monthStart.Month ? hideLink : null)}"),
                        new XAttribute("data-toggle",
                            $"tooltip"),
                        new XAttribute("title",
                            $"Группа: {e.Group.Name}({e.Group.Coach.NameSurname}) Время: {e.TimeStart.ToString("hh\\:mm")}-{e.TimeFinish.ToString("hh\\:mm")} Клиенты: {e.Group.Clients.Count(c => c.ClientType == ClientType.AreEngaged)}"),
                        new XAttribute("href", $"{e.Action}&date={d.Date:M/d/yy}"),
                        $"{e.Group.Name} ({e.TimeStart.ToString("hh\\:mm")}-{e.TimeFinish.ToString("hh\\:mm")}) {e.Group.Clients.Count(c=>c.ClientType == ClientType.AreEngaged)}"
                    )
                ) ?? new[]
                {
                    new XElement("p",
                        new XAttribute("class", $"d-lg-none {(d.Month != monthStart.Month ? hideLink : null)}"),
                        "Нет занятий в этот день"
                    )
                };
                
            }
        }
    }
}