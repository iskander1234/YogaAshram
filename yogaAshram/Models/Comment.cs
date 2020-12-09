using System;

namespace yogaAshram.Models
{
    public enum Reason
    {
        Заморозка,
        Пропуск,
        Другое,
        Отмена
    }
    public class Comment
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public Reason Reason { get; set; }
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}