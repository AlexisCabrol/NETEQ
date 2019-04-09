using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.models
{
    public class MediaGenre : AbstractModel
    {
        public int GenreId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre
        {
            get { return GetValue<Genre>(); }
            set { SetValue(value); }
        }

        public int MediaId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        [ForeignKey(nameof(MediaId))]
        public Media Media
        {
            get { return GetValue<Media>(); }
            set { SetValue(value); }
        }
    }
}
