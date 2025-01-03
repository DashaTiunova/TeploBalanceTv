using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecuperatorLibrary.Models
{
    /// <summary>
    /// Вариант
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// Id варианта
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Название варианта
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание варианта
        /// </summary>
        public string Desc { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
