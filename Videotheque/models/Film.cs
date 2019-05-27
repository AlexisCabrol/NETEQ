using System;

namespace Videotheque.models
{
    public class Film : Media, IComparable
    {
        public TimeSpan Duree
        {
            get { return GetValue<TimeSpan>(); }
            set { SetValue(value); }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Film otherFilm = obj as Film;
            if (otherFilm != null)
            {
                return this.Titre.CompareTo(otherFilm.Titre);
            }
            else
            {
                throw new ArgumentException("Object is not a Film");
            }
        }
    }
}
