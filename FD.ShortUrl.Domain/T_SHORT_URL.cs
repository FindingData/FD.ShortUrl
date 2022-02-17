

using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FD.ShortUrl.Domain
{
    
    [Table("T_SHORT_URL")]
	public partial class ShortUrlPO 
	{		      
         	        						  
         /// <summary>
		/// 短链ID
        /// </summary>    
            
		[Key]
		        public int  SHORT_URL_ID
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 短链码
        /// </summary>    
                public string  SHORT_CODE
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 链接URL
        /// </summary>    
                public string  URL
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 创建时间
        /// </summary>    
                public DateTime ? CREATED_TIME
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 创建人
        /// </summary>    
                public int ? CREATED_BY
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 修改时间
        /// </summary>    
                public DateTime ? MODIFIED_TIME
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 修改人
        /// </summary>    
                public int ? MODIFIED_BY
        {
            get;set;
        }	

     	        						  
         /// <summary>
		/// 是否删除
        /// </summary>    
                public int ? IS_DELETE
        {
            get;set;
        }	

    		
    }
}

