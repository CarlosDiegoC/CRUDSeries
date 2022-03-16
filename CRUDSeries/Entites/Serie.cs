using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSeries
{
    internal class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private Boolean IsDeleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            IsDeleted = false;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "ID: " + Id + Environment.NewLine;
            ret += "Genre: " + Genre + Environment.NewLine;
            ret += "Title: " + Title + Environment.NewLine;
            ret += "Description: " + Description + Environment.NewLine;
            ret += "Year: " + Year + Environment.NewLine;
            return ret;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
    }
}
