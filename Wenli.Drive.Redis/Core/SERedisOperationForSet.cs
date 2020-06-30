﻿/****************************************************************************
*项目名称：Wenli.Drive.Redis.Core
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Drive.Redis.Core
*类 名 称：SERedisOperationForSet
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/6/3 15:48:09
*描述：
*=====================================================================
*修改时间：2020/6/3 15:48:09
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using Wenli.Drive.Redis.Extends;
using Wenli.Drive.Redis.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Wenli.Drive.Redis.Core
{
    /// <summary>
    /// SERedisOperationForSet
    /// </summary>
    public partial class SERedisOperation : IRedisOperation
    {
        #region Set

        /// <summary>
        ///     添加一个set
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetAdd(string setId, string val)
        {
            return DoWithRetry(() =>
            {
                return _cnn.GetDatabase().SetAdd(setId, val);
            });
        }

        /// <summary>
        ///     是否存在于set中
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetContains(string setId, string val)
        {
            return DoWithRetry(() =>
            {
                return _cnn.GetDatabase().SetContains(setId, val);
            });
        }

        /// <summary>
        ///     获取某个key下面全部的value
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public List<string> SetMembers(string setId)
        {
            return DoWithRetry(() =>
            {
                return _cnn.GetDatabase().SetMembers(setId).ConvertTo();
            });
        }

        /// <summary>
        ///     移除set
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool SetRemove(string setId, string val)
        {
            return DoWithRetry(() =>
            {
                return _cnn.GetDatabase().SetRemove(setId, val);
            });
        }

        /// <summary>
        ///     批量删除set
        /// </summary>
        /// <param name="setId"></param>
        /// <param name="vals"></param>
        public void SetsRemove(string setId, string[] vals)
        {
            DoWithRetry(() =>
            {
                for (var i = 0; i < vals.Length; i++)
                    _cnn.GetDatabase().SetRemove(setId, vals[i]);
            });
        }

        /// <summary>
        ///     返回指定set长度
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public long SetLength(string setId)
        {
            return DoWithRetry(() =>
            {
                return _cnn.GetDatabase().SetLength(setId);
            });
        }

        #endregion
    }
}
