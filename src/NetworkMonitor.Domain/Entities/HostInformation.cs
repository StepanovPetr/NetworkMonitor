using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetworkMonitor.Domain.Entities
{
    [Table("HostInformation")]
    public class HostInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        /// <summary> Id. </summary>
        public int Id { get; set; }

        /// <summary> IP адрес DHCP Сервера. </summary>
        public string Dhcp { get; set; }

        /// <summary> IP адрес шлюза по-умолчанию. </summary>
        public string Gateway { get; set; }

        /// <summary> Имя машины. </summary>
        public string HostName { get; set; }

        [Column("Ipv4Address")]
        /// <summary> IP адрес машины. </summary>
        public string IPv4Address { get; set; }

        /// <summary> IP адреса DNS серверов. </summary>
        public string Dns { get; set; }
    }
}