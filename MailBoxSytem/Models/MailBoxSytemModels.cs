using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MailBoxSytem.Models
{
    public enum TemplateType
    {
        Email=0,
        SMS=1,
        firebase=2,
    }
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string GroupBy { get; set; }
        public TemplateType TemplateType { get; set; }
        public virtual ICollection<Parameters> Parameters { get; set; }

    }
    public class Layout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Style { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public TemplateType TemplateType { get; set; }
    }
    public class Parameters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Key { get; set; }
        public string Description { get; set; }
        public string ClassName { get; set; }
        [ForeignKey("Template")]
        public Guid TemplateId { get; set; }
        public virtual Template Template { get; set; }

    }
    public class TemplateDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        [ForeignKey("Template")]
        public Guid TemplateId { get; set; }
        public virtual Template Template { get; set; }

        //[ForeignKey("Layout")]
        //public Guid LayoutId { get; set; }
        public virtual Layout Layout { get; set; }
    }
}