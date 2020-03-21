using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace QinGy.DotNetCoreStudy.SystemUnitTest
{
    public class SimpleTest
    {
        [Fact]
        public void TestXmlSeriale()
        {
            List<WishShippingFeeRegionItem> esRetionList = new List<WishShippingFeeRegionItem>()
            {
                new WishShippingFeeRegionItem(){ 
                RegionCode="ES_CN",
                RegionName="Canary Islands",
                CountryCode="ES",
                Enabled=true,
                PlusFee=0,
                ShippFee=0,
                UseProductFee=true,
                },
            };
        }



//        ES_CN Canary Islands ES
//FR_GP Guadeloupe  FR
//FR_MF   Saint Martin    FR
//FR_MQ   Martinique FR
//FR_NC New Caledonia FR
//FR_PF French Polynesia FR
//FR_PM Saint Pierre and Miquelon FR
//FR_RE Reunion FR
//FR_WF   Wallis and Futuna FR
//FR_YT Mayotte FR
//US_AA   AA US
//US_AE AE  US
//US_AK   Alaska US
//US_AP AP  US
//US_AS   American Samoa  US
//US_GU   Guam US
//US_HI Hawaii  US
//US_MP   Northern Mariana Islands US
    }
    [Serializable]
    public class WishShippingFeeRegionItem
    {
        [XmlAttribute]
        public string RegionCode { get; set; }
        [XmlAttribute]
        public string RegionName { get; set; }
        [XmlAttribute]
        public string CountryCode { get; set; }

        /// <summary>
        /// 'True'/'False'. If 'True' then the product is available for sale in this country. 
        ///  If 'False' then the product is not available for sale in this Area.
        /// </summary>
        [XmlAttribute]
        public bool Enabled { get; set; }

        /// <summary>
        /// 国家配送费用
        /// </summary>
        [XmlAttribute]
        public double ShippFee { get; set; }

        /// <summary>
        /// 是否使用产品运费
        /// </summary>
        [XmlAttribute]
        public bool UseProductFee { get; set; }

        /// <summary>
        /// 附加费用
        /// </summary>
        [XmlAttribute]
        public double PlusFee { get; set; }
    }
}
