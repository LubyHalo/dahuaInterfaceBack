using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dahua.Card
{
    class CardParamSet
    {
        public string baseUrl = "http://10.100.4.14/CardSolution";
        public baseParamModels[] modelList =
        {
            #region 一卡通访客接口
            // 访客预约/查询访客预约信息
            new baseParamModels()
            {
                nodeName = "node1_1_2",
                url = "/card/visitor/getVisitorData",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100,
                    status = 1
                },
                isPost = true
            },
            // 访客信息/查询访客信息
            new baseParamModels()
            {
                nodeName = "node1_2_1",
                url = "/card/visitor/getVisitorData",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 访客信息/统计在访人数
            new baseParamModels()
            {
                nodeName = "node1_2_3",
                url = "/card/visitor/countVisiting",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 访客信息/查询单个访客信息
            new baseParamModels()
            {
                nodeName = "node1_2_4",
                url = "/card/visitor/getVisitorSingleRecordById/6",
                param = new
                {
                },
                isPost = false
            },
            // 访客黑名单/查询黑名单
            new baseParamModels()
            {
                nodeName = "node1_3_2",
                url = "/card/visitor/black/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = false
            },
            // 访客记录查询/超时报表
            new baseParamModels()
            {
                nodeName = "node1_4_1",
                url = "/card/visitor/getVisitorTimeOutData",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100,
                    v_box = 1
                },
                isPost = true
            },
            // 访客记录查询/刷卡记录查询
            new baseParamModels()
            {
                nodeName = "node1_4_2",
                url = "/card/accessControl/swingCardRecord/visitor/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 岗亭管理/查询岗亭
            new baseParamModels()
            {
                nodeName = "node1_5_3",
                url = "/card/visitor/box/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 日志管理/设备状态日志
            new baseParamModels()
            {
                nodeName = "node1_6_1",
                url = "/card/visitor/getVisitorDeviceLog",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 日志管理/管理日志
            new baseParamModels()
            {
                nodeName = "node1_6_2",
                url = "/card/visitor/getVisitorSystemLog",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
	        #endregion
            #region 一卡通考勤接口
            
            // 考勤点设置/查询考勤点
            new baseParamModels()
            {
                nodeName = "node2_1_4",
                url = "/attendance/site/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    singleCondition = "考勤点1"
                },
                isPost = true
            },
            // 考勤规则设置/查看考勤规则
            new baseParamModels()
            {
                nodeName = "node2_2_4",
                url = "/attendance/rule/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    singleCondition = "考勤规则1"
                },
                isPost = true
            },
            // 班次设置/查看班次
            new baseParamModels()
            {
                nodeName = "node2_3_4",
                url = "/attendance/daily/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    singleCondition = "班次名称1"
                },
                isPost = true
            },
            // 班组设置/查看班组
            new baseParamModels()
            {
                nodeName = "node2_4_4",
                url = "/attendance/group/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    singleCondition = "班组1"
                },
                isPost = true
            },
            // 班组设置/查看班组下的人员
            new baseParamModels()
            {
                nodeName = "node2_4_5",
                url = "/attendance/group/3/person/list",
                param = new
                {
                },
                isPost = true
            },
            // 排班设置/查询排班
            new baseParamModels()
            {
                nodeName = "node2_5_3",
                url = "/attendance/schedule/3/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 考勤调整/查询考勤调整单
            new baseParamModels()
            {
                nodeName = "node2_6_3",
                url = "/attendance/adjust/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    sortBy = "CREATE_TIME",
                    sortOrder = "DESC",
                    startTime = "2018-10-14 00:00:00",
                    endTime = "2018-10-19 23:59:59",
                    singleCondition = "34"
                },
                isPost = true
            },
            // 考勤调整/查询考勤调整原因(ADJUST 调休,EXCHANGE 改签,LEAVE请假,ERRAND 出差)
            new baseParamModels()
            {
                nodeName = "node2_6_7",
                url = "/attendance/adjust/type/ADJUST/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    singleCondition = "34"
                },
                isPost = true
            },
            // 考勤日志/考勤记录
            new baseParamModels()
            {
                nodeName = "node2_7_1",
                url = "/attendance/result/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 考勤日志/刷卡记录
            new baseParamModels()
            {
                nodeName = "node2_7_2",
                url = "/attendance/record/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 报表统计/报表统计
            new baseParamModels()
            {
                nodeName = "node2_8_1",
                url = "/attendance/result/stat/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
	        #endregion
            #region 一卡通门禁接口
            // 设备管理/查询设备
            new baseParamModels()
            {
                nodeName = "node3_1_4",
                url = "/card/accessControl/device/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 开门计划/查看开门计划
            new baseParamModels()
            {
                nodeName = "node3_2_4",
                url = "/card/accessControl/timeQuantum/1",
                param = new
                {
                    
                },
                isPost = false
            },
            // 门组权限/查看门组权限
            new baseParamModels()
            {
                nodeName = "node3_3_4",
                url = "/card/accessControl/doorGroup/2346613",
                param = new
                {

                },
                isPost = true
            },
            // 按人授权/查询人员授权
            new baseParamModels()
            {
                nodeName = "node3_4_1",
                url = "/card/accessControl/doorAuthority/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 按人授权/根据卡号查询人员权限
            new baseParamModels()
            {
                nodeName = "node3_4_5",
                url = "/card/accessControl/doorAuthority/00001507",
                param = new
                {

                },
                isPost = true
            },
            // 按门授权/查询人员权限
            new baseParamModels()
            {
                nodeName = "node3_5_1",
                url = "/card/accessControl/doorAuthority/ChannelWithAuthorizeStatus/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 发卡复核/查询复核结果
            new baseParamModels()
            {
                nodeName = "node3_6_3",
                url = "/card/accessControl/sendCardCheckAgain/bycondition/combined",
                param = new
                {
                    deviceCode = "1000013",
                    isOnlyShowDiff = false,
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 记录查询/刷卡记录查询
            new baseParamModels()
            {
                nodeName = "node3_8_1",
                url = "/card/accessControl/swingCardRecord/bycondition/combined",
                param = new
                {
                    startSwingTime = "2018-11-01 17:50:00",
                    endSwingTime = "2018-11-04 17:53:00",
                    pageNum = 1,
                    pageSize = 100,
                    openType = 61
                },
                isPost = true
            },
            // 设备状态日志/查询设备状态
            new baseParamModels()
            {
                nodeName = "node3_9_1",
                url = "/card/accessControl/swingCardRecord/bycondition/combined",
                param = new
                {
                    deviceCode = "1000013",
                    startDate = "2018-10-17 00:00:00",
                    endDate = "2018-10-27 23:59:59",
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
            // 服务查询/服务查询
            new baseParamModels()
            {
                nodeName = "node3_10_1",
                url = "/card/accessControl/swingCardRecord/getServiceList",
                param = new
                {
                    pageNum = 1,
                    pageSize = 100
                },
                isPost = true
            },
        #endregion
            #region 一卡通人员卡片接口
            
            // 人员管理/查询人员
            new baseParamModels()
            {
                nodeName = "node4_1_5",
                url = "/card/person/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 卡片管理/卡片查询
            new baseParamModels()
            {
                nodeName = "node4_2_6",
                url = "/card/card/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
	        #endregion
            #region 一卡通梯控接口
            
            // 梯控管理/获取所有梯控
            new baseParamModels()
            {
                nodeName = "node5_1_4",
                url = "/card/ecs/elevator",
                param = new
                {
                },
                isPost = false
            },
            // 梯控授权/查询梯控授权
            new baseParamModels()
            {
                nodeName = "node5_2_1",
                url = "/card/ecs/elevator/card/authorizable",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 梯控授权/根据卡号查询梯控授权
            new baseParamModels()
            {
                nodeName = "node5_2_3",
                url = "/card/ecs/elevator/authorization/bycondition/card/00000112",
                param = new
                {
                },
                isPost = true
            },
	        #endregion
            #region 一卡通系统配置接口
            
            // 节假日配置/查询节假日
            new baseParamModels()
            {
                nodeName = "node6_1_4",
                url = "/attendance/holiday/page",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 身份配置/查询身份
            new baseParamModels()
            {
                nodeName = "node6_2_4",
                url = "/card/person/personidentity",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = false
            },
	        #endregion
            #region 一卡通消费接口
            
            // 营业单位管理/查询营业单位
            new baseParamModels()
            {
                nodeName = "node7_1_4",
                url = "/card/merchant",
                param = new
                {
                },
                isPost = false
            },
            // 消费设备/查询消费设备
            new baseParamModels()
            {
                nodeName = "node7_2_4",
                url = "/card/terminal/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 规则设置/查询营业时间段
            new baseParamModels()
            {
                nodeName = "node7_3_4",
                url = "/card/consumption/business_time",
                param = new
                {
                },
                isPost = false
            },
            // 日志查询/消费日志
            new baseParamModels()
            {
                nodeName = "node7_5_1",
                url = "/card/consumption/card_consumption_record/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 日志查询/充值日志
            new baseParamModels()
            {
                nodeName = "node7_5_2",
                url = "/card/consumption/card_cash_record/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 报表统计/营收收入
            new baseParamModels()
            {
                nodeName = "node7_6_1",
                url = "/card/consumption/statistical_report/merchant",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 报表统计/人员消费
            new baseParamModels()
            {
                nodeName = "node7_6_2",
                url = "/card/consumption/statistical_report/person/consumption",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 报表统计/现金交易
            new baseParamModels()
            {
                nodeName = "node7_6_3",
                url = "/card/consumption/statistical_report/person/cash",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 消费授权/查询授权
            new baseParamModels()
            {
                nodeName = "node7_8_4",
                url = "/card/consumption/terminal/authorization",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
	        #endregion
            #region 一卡通巡更接口
            
            // 巡更点设置/查询巡更点
            new baseParamModels()
            {
                nodeName = "node8_1_4",
                url = "/card/patrol/point/queryById",
                param = new
                {
                    id = 2
                },
                isPost = true
            },
            // 巡更点设置/查询巡更点列表
            new baseParamModels()
            {
                nodeName = "node8_1_5",
                url = "/card/patrol/point/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    pointType = 1
                },
                isPost = true
            },
            // 班组设置/查询班组
            new baseParamModels()
            {
                nodeName = "node8_2_4",
                url = "/card/patrol/classGroup/queryById",
                param = new
                {
                    id = 2
                },
                isPost = true
            },
            // 班组设置/查询班组列表
            new baseParamModels()
            {
                nodeName = "node8_2_5",
                url = "/card/patrol/classGroup/bycondition/combined",
                //url = "/card/patrol/route/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 线路设置/查询线路
            new baseParamModels()
            {
                nodeName = "node8_3_4",
                url = "/card/patrol/route/queryById",
                param = new
                {
                    id = 2
                },
                isPost = true
            },
            // 巡更点设置/查询线路列表
            new baseParamModels()
            {
                nodeName = "node8_3_5",
                url = "/card/patrol/route/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 排班设置/查询排班
            new baseParamModels()
            {
                nodeName = "node8_4_4",
                url = "/card/patrol/orderClass/queryById",
                param = new
                {
                    id = 2
                },
                isPost = true
            },
            // 排班设置/查询排班列表
            new baseParamModels()
            {
                nodeName = "node8_4_5",
                url = "/card/patrol/orderClass/bycondition/combined",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20
                },
                isPost = true
            },
            // 记录查询/查询巡更点记录
            new baseParamModels()
            {
                nodeName = "node8_5_1",
                url = "/card/patrol/record/point",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startPlanPatrolTime = "2018-10-18",
                    endPlanPatrolTime = "2018-10-28"
                },
                isPost = true
            },
            // 记录查询/导出巡更点记录
            new baseParamModels()
            {
                nodeName = "node8_5_2",
                url = "/card/patrol/record/pointExport",
                param = new
                {
                    startPlanPatrolTime = "2018-10-18",
                    endPlanPatrolTime = "2018-10-28"
                },
                isPost = true
            },
            // 记录查询/查询巡更路线记录
            new baseParamModels()
            {
                nodeName = "node8_5_3",
                url = "/card/patrol/record/route",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startOrderClassDate = "2018-10-18",
                    endOrderClassDate = "2018-10-28"
                },
                isPost = true
            },
            // 记录查询/导出巡更路线记录
            new baseParamModels()
            {
                nodeName = "node8_5_4",
                url = "/card/patrol/record/routeExport",
                param = new
                {
                    startOrderClassDate = "2018-10-18",
                    endOrderClassDate = "2018-10-28"
                },
                isPost = true
            },
            // 记录查询/查询刷卡记录
            new baseParamModels()
            {
                nodeName = "node8_5_5",
                url = "/card/patrol/record/swing",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startSwingTime = "2018-10-18",
                    endSwingTime = "2018-10-28"
                },
                isPost = true
            },
            // 记录查询/导出刷卡记录
            new baseParamModels()
            {
                nodeName = "node8_5_6",
                url = "/card/patrol/record/swingExport",
                param = new
                {
                    startSwingTime = "2018-10-18",
                    endSwingTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/查询巡更路线报表
            new baseParamModels()
            {
                nodeName = "node8_6_1",
                url = "/card/patrol/statistic/route",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/导出巡更路线报表
            new baseParamModels()
            {
                nodeName = "node8_6_2",
                url = "/card/patrol/statistic/route/download",
                param = new
                {
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/查询巡更点报表
            new baseParamModels()
            {
                nodeName = "node8_6_3",
                url = "/card/patrol/statistic/point",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/导出巡更点报表
            new baseParamModels()
            {
                nodeName = "node8_6_4",
                url = "/card/patrol/statistic/point/download",
                param = new
                {
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/查询巡更人员报表
            new baseParamModels()
            {
                nodeName = "node8_6_5",
                url = "/card/patrol/statistic/person",
                param = new
                {
                    pageNum = 1,
                    pageSize = 20,
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            },
            // 报表统计/导出巡更人员报表
            new baseParamModels()
            {
                nodeName = "node8_6_6",
                url = "/card/patrol/statistic/person/download",
                param = new
                {
                    startTime = "2018-10-18",
                    endTime = "2018-10-28"
                },
                isPost = true
            }
	        #endregion
        };
    }
}
