using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dahua;

namespace dahua.InterfaceParams
{
    class CardParams
    {
        //public string baseUrl = "http://10.100.4.14/CardSolution";
        public string baseUrl = "http://60.191.94.122:9331/CardSolution";

		private dahuajk dhjk = new dahuajk("http://60.191.94.122:9331/WPMS", "8900yanshi", "8900yanshi1", false, true);
		public string getPwd(string content)
		{
			return dhjk.getRSAEncryptPassWord(baseUrl + "/rsa/getPubKey", content);
		}

		public baseParamModels[] modelList()
		{
			baseParamModels[] modelList =
			{
				#region 1.一卡通访客接口(√)
					#region 1.访客预约(√-)
					// 访客预约/访客预约(I/O error: Connection refused; nested exception is java.net.ConnectException: Connection refused)
					new baseParamModels()
					{
						nodeName = "node1_1_1",
						url = "/card/visitor/insertVisitor",
						param = new
						{
							v_name = "访客1",
							v_phone = "13750856146",
							v_dw = "ws",
							v_address = "cccccc",
							v_certificateType = "身份证",
							v_certificateNumber = "320723199504243611",
							v_reason = "参观",
							v_personSum = 3,
							isv_id = 1,
							//v_time = Convert.ToDateTime("2018-03-12 00:00:00").ToString("o"),
							v_time = "2018-03-12T00:00:00.000Z",
							//v_lvTime = Convert.ToDateTime("2018-03-14 00:00:00").ToString("o"),
							v_lvTime = "2018-03-14T00:00:00.000Z",
							memo = "备注",
							status = 1,
							//v_plateNumber = "浙A12334"
						},
						isPost = true
					},
					// 访客预约/查询访客预约信息(√)
					new baseParamModels()
					{
						nodeName = "node1_1_2",
						url = "/card/visitor/getVisitorData",
						param = new
						{
							pageNum = 1,
							pageSize = 100,
							//status = 1
						},
						isPost = true
					},
					// 访客预约/修改访客预约信息(I/O error: Connection refused; nested exception is java.net.ConnectException: Connection refused)
					new baseParamModels()
					{
						nodeName = "node1_1_3",
						url = "/card/visitor/updateVisitor",
						param = new
						{
							v_name = "访客1",
							v_phone = "13750856146",
							v_dw = "单位1",
							v_address = "cccccc",
							v_certificateType = "身份证",
							v_certificateNumber = "320723199504243611",
							v_reason = "参观",
							v_personSum = 3,
							isv_id = 1,
							v_time = Convert.ToDateTime("2018-03-12 00:00:00").ToString("o"),
							v_lvTime = Convert.ToDateTime("2018-03-12 00:00:00").ToString("o"),
							memo = "备注",
							status = 1,
							v_plateNumber = "浙A12334",
							id = 6
						},
						isPost = true
					},
					// 访客预约/修改访客状态信息(√)
					new baseParamModels()
					{
						nodeName = "node1_1_4",
						url = "/card/visitor/changeBookStatusByIds",
						param = new
						{
							ids = "6",
							status = 1
						},
						isPost = true
					},
					#endregion
					#region 2.访客信息(√-)
					// 访客信息/查询访客信息(√)
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
					// 访客信息/访客退卡(√)
					new baseParamModels()
					{
						nodeName = "node1_2_2",
						url = "/card/visitor/returnCard/6",
						param = new
						{
						},
						isPost = true
					},
					// 访客信息/统计在访人数(√)
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
					// 访客信息/查询单个访客信息(√)
					new baseParamModels()
					{
						nodeName = "node1_2_4",
						url = "/card/visitor/getVisitorSingleRecordById/7",
						param = new
						{
						},
						isPost = false
					},
					// 访客信息/访客发卡(√)-1
					new baseParamModels()
					{
						nodeName = "node1_2_6",
						url = "/configGuide/addCard",
						param = new
						{
							availableTimes = "255",
							cardCash = 0,
							cardCost = 0,
							cardDeposit = 0,
							cardNumber = "A1234568",
							cardPassword = "123456",
							cardStatus = "ACTIVE",
							cardType = 2,
							category = "0",
							endDate = "2019-10-10 23:59:59",
							startDate = "2017-02-23 18:18:51",
							subSystems = "1,3,4,5,6"
						},
						isPost = true
					},
					// 访客信息/修改访客卡号(人卡绑定)(√)-2
					new baseParamModels()
					{
						nodeName = "node1_2_5",
						url = "/card/visitor/updateVisitorCard",
						param = new
						{
							id = 6,
							v_cardType = "2",
							v_CardNumber = "A1234568"
						},
						isPost = true
					},
					// 访客信息/访客卡权限发放(√-)-3
					new baseParamModels()
					{
						nodeName = "node1_2_7",
						url = "/configGuide/giveUserDoorRight",
						param = new
						{
							cardNumber = "A1234568",
							handle = "insert",
							timeQuantumId = 7,
							authorizeSource = "1",
							doorList = new object[] {
								new {
									resourceCode = "1000004$7$0$0",
									cardNumber = "A1234568",
									privilegeType = 1

								},
								new {
									resourceCode = "1000004$7$0$0",
									cardNumber = "A1234568",
									privilegeType = 1
								}
							}
						},
						isPost = true
					},
					#endregion
					#region 3.访客黑名单(√)
					// 访客黑名单/添加访客黑名单(√)
					new baseParamModels()
					{
						nodeName = "node1_3_1",
						url = "/card/visitor/black/add",
						param = new
						{
							v_name = "黑名单测试1",
							v_sex = "FEMALE",
							v_phone = "13750856464",
							v_certificateNumber = "3207231995364635",
							v_certificateType = "身份证",
							memo = "4343"
						},
						isPost = true
					},
					// 访客黑名单/查询黑名单(√)
					new baseParamModels()
					{
						nodeName = "node1_3_2",
						url = "/card/visitor/black/bycondition/combined",
						param = new
						{
							pageNum = 1,
							pageSize = 20
							//v_name = "e34343",
							//v_certificateNumber = "3207231995364633",
							//v_sex = "FEMALE"
						},
						isPost = true
					},
					// 访客黑名单/删除黑名单(√)
					new baseParamModels()
					{
						nodeName = "node1_3_3",
						url = "/card/visitor/black/delete",
						param = new
						{
							ids = new string[] { "4" }
						},
						isPost = true
					},
					// 访客黑名单/修改访客黑名单(√)
					new baseParamModels()
					{
						nodeName = "node1_3_4",
						url = "/card/visitor/black/update",
						param = new
						{
							v_name = "黑名单测试1",
							v_sex = "FEMALE",
							v_phone = "13750856463",
							v_certificateNumber = "320723199536463X",
							v_certificateType = "身份证",
							memo = "4343",
							id = 4
						},
						isPost = true
					},
					#endregion
					#region 4.访客记录查询(√)
					// 访客记录查询/超时报表(√)
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
					// 访客记录查询/刷卡记录查询(√)
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
					#endregion
					#region 5.岗亭管理(√)
					// 岗亭管理/添加岗亭(√)
					new baseParamModels()
					{
						nodeName = "node1_5_1",
						url = "/card/visitor/box/add",
						param = new
						{
							v_boxName = "测试岗亭1",
							v_boxCode = "34343",
							v_boxIp = "10.10.10.10",
							status = 0,
							memo = "备注1"
						},
						isPost = true
					},
					// 岗亭管理/修改岗亭(√)
					new baseParamModels()
					{
						nodeName = "node1_5_2",
						url = "/card/visitor/box/update",
						param = new
						{
							v_boxName = "测试岗亭1改",
							v_boxCode = "34343",
							v_boxIp = "10.10.10.10",
							status = 0,
							memo = "备注1",
							id = 7
						},
						isPost = true
					},
					// 岗亭管理/查询岗亭(√)
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
					// 岗亭管理/删除岗亭(√)
					new baseParamModels()
					{
						nodeName = "node1_5_4",
						url = "/card/visitor/box/delete",
						param = new
						{
							ids = new int[] {7}
						},
						isPost = true
					},
					#endregion
					#region 6.日志管理(√)
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
				#endregion
				#region 2.一卡通考勤接口(暂不使用)
					#region 1.考勤点设置
					// 考勤点设置/考勤点添加
					new baseParamModels()
					{
						nodeName = "node2_1_1",
						url = "/attendance/site",
						param = new
						{
							name = "测试考勤点1",
							type = "BOTH",
							readerId = 4
						},
						isPost = true
					},
					// 考勤点设置/考勤点修改(√)
					new baseParamModels()
					{
						nodeName = "node2_1_2",
						url = "/attendance/site/update",
						param = new
						{
							name = "大门考勤点",
							type = "BOTH",
							readerId = 3,
							id = 1
						},
						isPost = true
					},
					// 考勤点设置/考勤点删除
					new baseParamModels()
					{
						nodeName = "node2_1_3",
						url = "/attendance/site/delete",
						param = new
						{
							ids = new int[] {2}
						},
						isPost = true
					},
					// 考勤点设置/查询考勤点(√)
					new baseParamModels()
					{
						nodeName = "node2_1_4",
						url = "/attendance/site/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//singleCondition = "考勤点1"
						},
						isPost = true
					},
					#endregion
					#region 2.考勤规则设置(√)
					// 考勤规则设置/添加考勤规则(√)
					new baseParamModels()
					{
						nodeName = "node2_2_1",
						url = "/attendance/rule",
						param = new
						{
							name = "测试考勤1",
							type = "COMMOM",
							ruleContext = "{\"checkinAhead\":\"240\",\"checkinLateDelay\":\"5\",\"absentDelay\":\"120\",\"checkoutAhead\":\"300\",\"checkoutEarlyAhead\":\"5\",\"absentAhead\":\"120\",\"overtimeAfterCheckoutDelay\":\"60\",\"eachOvertimeMinutes\":\"120\",\"overtimeAmountEveryday\":\"2\",\"spanDay\":\"1\"}",
							comment = "备注1"
						},
						isPost = true
					},
					// 考勤规则设置/修改考勤规则(√)
					new baseParamModels()
					{
						nodeName = "node2_2_2",
						url = "/attendance/rule/update",
						param = new
						{
							name = "测试考勤1改",
							type = "COMMOM",
							ruleContext = "{\"checkinAhead\":\"240\",\"checkinLateDelay\":\"5\",\"absentDelay\":\"120\",\"checkoutAhead\":\"300\",\"checkoutEarlyAhead\":\"5\",\"absentAhead\":\"120\",\"overtimeAfterCheckoutDelay\":\"60\",\"eachOvertimeMinutes\":\"120\",\"overtimeAmountEveryday\":\"2\",\"spanDay\":\"1\"}",
							comment = "备注1",
							id = "2"
						},
						isPost = true
					},
					// 考勤规则设置/删除考勤规则(√)
					new baseParamModels()
					{
						nodeName = "node2_2_3",
						url = "/attendance/rule/delete",
						param = new
						{
							ids = new int[] {2}
						},
						isPost = true
					},
					// 考勤规则设置/查看考勤规则(√)
					new baseParamModels()
					{
						nodeName = "node2_2_4",
						url = "/attendance/rule/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//singleCondition = "考勤规则1"
						},
						isPost = true
					},
					#endregion
					#region 3.班次设置(√)
					// 班次设置/添加班次
					new baseParamModels()
					{
						nodeName = "node2_3_1",
						url = "/attendance/daily",
						param = new
						{
							name = "测试班次1",
							segments = new object[]
							{
								new
								{
									checkin = "03:00",
									checkout = "07:00",
									ruleId = "1",
									order = 0
								},
								new
								{
									checkin = "07:02",
									checkout = "08:02",
									ruleId = "2",
									order = 1
								},
								new
								{
									checkin = "11:00",
									checkout = "11:20",
									ruleId = "3",
									order = 2
								},
								new
								{
									checkin = "18:00",
									checkout = "22:33",
									ruleId = "2",
									order = 3
								}
							}
						},
						isPost = true
					},
					// 班次设置/删除班次
					new baseParamModels()
					{
						nodeName = "node2_3_2",
						url = "/attendance/daily/delete",
						param = new
						{
							ids = new int[] {39}
						},
						isPost = true
					},
					// 班次设置/修改班次
					new baseParamModels()
					{
						nodeName = "node2_3_3",
						url = "/attendance/daily/update",
						param = new
						{
							id = 39,
							name = "测试班次1改",
							segments = new object[]
							{
								new
								{
									checkin = "03:00",
									checkout = "07:00",
									ruleId = "1",
									order = 0
								},
								new
								{
									checkin = "07:02",
									checkout = "08:02",
									ruleId = "2",
									order = 1
								},
								new
								{
									checkin = "11:00",
									checkout = "11:20",
									ruleId = "3",
									order = 2
								},
								new
								{
									checkin = "18:00",
									checkout = "22:33",
									ruleId = "2",
									order = 3
								}
							}
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
							//singleCondition = "班次名称1"
						},
						isPost = true
					},
					#endregion
					#region 4.班组设置
					// 班组设置/添加班组(√)
					new baseParamModels()
					{
						nodeName = "node2_4_1",
						url = "/attendance/group",
						param = new
						{
							name = "测试班组1",
							personIds = new int[] {12, 13},
							comment = "备注1"
						},
						isPost = true
					},
					// 班组设置/删除班组(√)
					new baseParamModels()
					{
						nodeName = "node2_4_2",
						url = "/attendance/group/delete",
						param = new
						{
							ids = new int[] {1}
						},
						isPost = true
					},
					// 班组设置/修改班组(√)
					new baseParamModels()
					{
						nodeName = "node2_4_3",
						url = "/attendance/group/update",
						param = new
						{
							id = 1,
							name = "测试班组1改",
							addPersons = new int[] {6},
							deletePersons = new int[] {12, 13},
							comment = "备注1改"
						},
						isPost = true
					},
					// 班组设置/查看班组(√)
					new baseParamModels()
					{
						nodeName = "node2_4_4",
						url = "/attendance/group/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//singleCondition = "班组1"
						},
						isPost = true
					},
					// 班组设置/查看班组下的人员(x:500)
					new baseParamModels()
					{
						nodeName = "node2_4_5",
						url = "/attendance/group/1/person/list",
						param = new
						{
						},
						isPost = true
					},
					#endregion
					#region 5.排班设置
					// 排班设置/添加排班(cannot find schedule contex as type:[COMMOM] and context:)
					new baseParamModels()
					{
						nodeName = "node2_5_1",
						url = "/attendance/schedule/1",
						param = new
						{
							type = "COMMOM",
							startDate = "2017-03-01",
							endDate = "2018-03-01",
							//scheduleContext = new
							//{
							//    dailyCircle = new string[] {"37", "37", "37", "37", "37", "37", "37" },
							//    holidays = "null"
							//}
							scheduleContext = "{\"dailyCircle\":[\"37\",\"37\",\"37\",\"37\",\"37\",\"37\",\"37\"],\"holidays\":\"null\"}"
						},
						isPost = true
					},
					// 排班设置/删除排班(√)
					new baseParamModels()
					{
						nodeName = "node2_5_2",
						url = "/attendance/schedule/11/delete",
						param = new
						{
							ids = new int[] {11,12}
						},
						isPost = true
					},
					// 排班设置/查询排班(√)
					new baseParamModels()
					{
						nodeName = "node2_5_3",
						url = "/attendance/schedule/1/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20
						},
						isPost = true
					},
					#endregion
					#region 6.考勤调整(?)
					// 考勤调整/添加考勤调整单(√?:500)
					new baseParamModels()
					{
						nodeName = "node2_6_1",
						url = "/attendance/adjust",
						param = new
						{
							personId = 3,
							classify = "ADJUST",
							type = 1,
							scheduleDate = "2017-03-01",
							dailyId = 39,
							segment = new {
								checkin = "05:00:00",
								checkinNecessary = false,
								checkout = "17:00:00",
								checkoutNecessary = false,
								dailyCount = 0,
								order = 0,
								ruleId = 1
							},
							comment = "备注1"
						},
						isPost = true
					},
					// 考勤调整/删除考勤调整单(√)
					new baseParamModels()
					{
						nodeName = "node2_6_2",
						url = "/attendance/adjust/delete",
						param = new
						{
							ids = new int[] {3}
						},
						isPost = true
					},
					// 考勤调整/查询考勤调整单(√)
					new baseParamModels()
					{
						nodeName = "node2_6_3",
						url = "/attendance/adjust/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//sortBy = "CREATE_TIME",
							//sortOrder = "DESC",
							//startTime = "2018-10-14 00:00:00",
							//endTime = "2018-10-19 23:59:59",
							//singleCondition = "34"
						},
						isPost = true
					},
					// 考勤调整/添加调整原因(√)
					new baseParamModels()
					{
						nodeName = "node2_6_4",
						url = "/attendance/adjust/type",
						param = new
						{
							classifyId = "ADJUST",
							name = "测试调整原因1",
							unit = 1
						},
						isPost = true
					},
					// 考勤调整/删除考勤原因(√)
					new baseParamModels()
					{
						nodeName = "node2_6_5",
						url = "/attendance/adjust/type/delete",
						param = new
						{
							ids = new int[] {2}
						},
						isPost = true
					},
					// 考勤调整/修改调整原因(√)
					new baseParamModels()
					{
						nodeName = "node2_6_6",
						url = "/attendance/adjust/type/update",
						param = new
						{
							classifyId = "ADJUST",
							name = "测试调整原因1改",
							unit = 1,
							id = 2
						},
						isPost = true
					},
					// 考勤调整/查询考勤调整原因(ADJUST 调休,EXCHANGE 改签,LEAVE请假,ERRAND 出差)(√)
					new baseParamModels()
					{
						nodeName = "node2_6_7",
						url = "/attendance/adjust/type/ADJUST/page",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//singleCondition = "34"
						},
						isPost = true
					},
					#endregion
					#region 7.考勤日志(√)
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
					#endregion
					#region 8.报表统计(√)
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
				#endregion
				#region 3.一卡通门禁接口(√)
					#region 1.设备管理(√-)
					// 设备管理/增加设备(√)
					new baseParamModels()
					{
						nodeName = "node3_1_1",
						url = "/card/accessControl/device",
						param = new
						{
							manufacturer = "1",
							accessThirdPartyOpenDoor = "0",
							deviceName = "ceshi1",
							orgCode = "001",
							deviceModel = "2",
							accessChnNum = "1",
							deviceIp = "10.10.10.10",
							devicePort = "37777",
							deviceUser = "admin",
							devicePassword = getPwd("123456"),
							serviceId = "7007",
							accessControlChannelList = new object[] {
								new {
									channelSeq = 0,
									channelName = "ceshi1_通道1",
									validFlag = "1",
									status = "5",
									delayTime = "3",
									orgCode = "001",
									cardReaderList = new object[] {
										new {
											name = "ceshi1_通道1_读卡器1",
											businessType = "1",
											openType = "8",
											code = 1
										},
										new {
											name = "ceshi1_通道1_读卡器2",
											businessType = "2",
											openType = "8",
											code = 2
										}
									}
								}
							}
						},
						isPost = true
					},
					// 设备管理/删除设备(√)
					new baseParamModels()
					{
						nodeName = "node3_1_2",
						url = "/card/accessControl/device/delete/batch",
						param = new
						{
							accessControlDeviceIds = new int[] { 9 }
						},
						isPost = true
					},
					// 设备管理/修改设备(√)
					new baseParamModels()
					{
						nodeName = "node3_1_3",
						url = "/card/accessControl/device/update",
						param = new
						{
							id = 8,
							deviceCode = "1000014",
							manufacturer = "1",
							accessThirdPartyOpenDoor = "0",
							deviceName = "ceshi2",
							orgCode = "001",
							deviceModel = "2",
							accessChnNum = "1",
							deviceIp = "10.10.10.10",
							devicePort = "37777",
							deviceUser = "admin",
							devicePassword = getPwd("123456"),
							serviceId = "7007",
							accessControlChannelList = new object[] {
								new {
									channelSeq = 0,
									channelName = "ceshi1_通道1",
									validFlag = "1",
									status = "5",
									delayTime = "3",
									orgCode = "001",
									cardReaderList = new object[] {
										new {
											name = "ceshi1_通道1_读卡器1",
											businessType = "1",
											openType = "8",
											code = 1
										},
										new {
											name = "ceshi1_通道1_读卡器2",
											businessType = "2",
											openType = "8",
											code = 2
										}
									}
								}
							}
						},
						isPost = true
					},
					// 设备管理/查询设备(√)
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
					// 设备管理/查询通道(√)
					new baseParamModels()
					{
						nodeName = "node3_1_5",
						url = "/card/accessControl/channel/bycondition/combined",
						param = new
						{
							pageNum = 1,
							pageSize = 100,
							//singleCondition = "1",
							//orgCode = "001"
						},
						isPost = true
					},
					// 设备管理/清空重发设备权限(false)
					new baseParamModels()
					{
						nodeName = "node3_1_6",
						url = "/card/accessControl/device/clearCard",
						param = new
						{
							accessControlDeviceIds = new int[] {8}
						},
						isPost = true
					},
					#endregion
					#region 2.开门计划(√)
					// 开门计划/增加开门计划(√)
					new baseParamModels()
					{
						nodeName = "node3_2_1",
						url = "/card/accessControl/timeQuantum",
						param = new
						{
							type = 1,
							name = "测试开门计划1",
							memo = "开门计划1",
							detail = Newtonsoft.Json.JsonConvert.SerializeObject(new
							{
								monday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								tuesday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								wednesday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								thursday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								friday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								saturday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								sunday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
							})
						},
						isPost = true
					},
					// 开门计划/删除开门计划(√)
					new baseParamModels()
					{
						nodeName = "node3_2_2",
						url = "/card/accessControl/timeQuantum/delete",
						param = new
						{
							ids = new int[] {7}
						},
						isPost = true
					},
					// 开门计划/修改开门计划(√)
					new baseParamModels()
					{
						nodeName = "node3_2_3",
						url = "/card/accessControl/timeQuantum/update",
						param = new
						{
							type = 1,
							name = "测试开门计划1",
							memo = "开门计划1",
							detail = Newtonsoft.Json.JsonConvert.SerializeObject(new
							{
								monday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								tuesday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								wednesday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								thursday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								friday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								saturday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
								sunday = new string[] { "00:00-23:59", "00:00-00:00", "00:00-00:00", "00:00-00:00" },
							}),
							id = 7
						},
						isPost = true
					},
					// 开门计划/查看开门计划(√)
					new baseParamModels()
					{
						nodeName = "node3_2_4",
						url = "/card/accessControl/timeQuantum/7",
						param = new
						{

						},
						isPost = false
					},
					#endregion
					#region 3.门组权限(√)
					// 门组权限/增加门组权限
					new baseParamModels()
					{
						nodeName = "node3_3_1",
						url = "/card/accessControl/doorGroup",
						param = new
						{
							name = "测试门组权限",
							memo = "测试备注",
							doorGroupDetail = new object[]
							{
								new
								{
									channelCode = "1000002$7$0$0"
								},
								new
								{
									channelCode = "1000004$7$0$0"
								}
							}
						},
						isPost = true
					},
					// 门组权限/删除门组权限
					new baseParamModels()
					{
						nodeName = "node3_3_2",
						url = "/card/accessControl/doorGroup/delete/batch",
						param = new
						{
							doorGroupIds = new int[] {5}
						},
						isPost = true
					},
					// 门组权限/修改门组权限
					new baseParamModels()
					{
						nodeName = "node3_3_3",
						url = "/card/accessControl/doorGroup/update",
						param = new
						{
							id = 5,
							name = "测试门组权限改",
							memo = "测试备注改",
							addDoorGroupRelDoorList = new object[]
							{
								new
								{
									channelCode = "1000002$7$0$0"
								},
								new
								{
									channelCode = "1000004$7$0$0"
								}
							},
							deleteDoorGroupRelDoorList = new object[]
							{
								new
								{
									channelCode = "1000002$7$0$0"
								},
								new
								{
									channelCode = "1000004$7$0$0"
								}
							}
						},
						isPost = true
					},
					// 门组权限/查看门组权限
					new baseParamModels()
					{
						nodeName = "node3_3_4",
						url = "/card/accessControl/doorGroup/5",
						param = new
						{

						},
						isPost = true
					},
					#endregion
					#region 4.按人授权(√)
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
					// 按人授权/添加人员授权
					new baseParamModels()
					{
						nodeName = "node3_4_2",
						url = "/card/accessControl/doorAuthority",
						param = new
						{
							cardNumbers = new string[] {
								"11111111"
							},
							timeQuantumId = "1",
							cardPrivilegeDetails = new object[] {
								new {
									privilegeType = "1",
									resouceCode = "1000002$7$0$0"
								}
							}
						},
						isPost = true
					},
					// 按人授权/人员权限修改
					new baseParamModels()
					{
						nodeName = "node3_4_3",
						url = "/card/accessControl/doorAuthority/update",
						param = new
						{
							cardNumber = "11111111",
							timeQuantumId = "1",
							cardPrivilegeDetails = new object[] {
								new {
									privilegeType = "1",
									resouceCode = "1000004$7$0$0"
								}
							}
						},
						isPost = true
					},
					// 按人授权/人员权限删除
					new baseParamModels()
					{
						nodeName = "node3_4_4",
						url = "/card/accessControl/doorAuthority/delete/batch",
						param = new
						{
							cardNums = new string[] { "11111111" }
						},
						isPost = true
					},
					// 按人授权/根据卡号查询人员权限
					new baseParamModels()
					{
						nodeName = "node3_4_5",
						url = "/card/accessControl/doorAuthority/11111111",
						param = new
						{

						},
						isPost = true
					},
					#endregion
					#region 5.按门授权(√)
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
					// 按门授权/按门按人授权
					new baseParamModels()
					{
						nodeName = "node3_5_2",
						url = "/card/accessControl/doorAuthority/authorizeAllPersonByChannelCode",
						param = new
						{
							timeQuantumId = "1",
							personIdsString = "1",
							channelCode = "1000002$7$0$0"
						},
						isPost = true
					},
					// 按门授权/按门删除人员授权
					new baseParamModels()
					{
						nodeName = "node3_5_3",
						url = "/card/accessControl/doorAuthority/removeAuthorizeAllPersonByChannelCode",
						param = new
						{
							personIdsString = "1",
							channelCode = "1000002$7$0$0"
						},
						isPost = true
					},
					// 按门授权/按部门按通道授权
					new baseParamModels()
					{
						nodeName = "node3_5_4",
						url = "/card/accessControl/doorAuthority/authorizeAllDeptByChannelCode",
						param = new
						{
							timeQuantumId = "1",
							deptIdsString = "1",
							channelCode = "1000002$7$0$0"
						},
						isPost = true
					},
					// 按门授权/按门删除部门授权
					new baseParamModels()
					{
						nodeName = "node3_5_5",
						url = "/card/accessControl/doorAuthority/removeAuthorizeAllByChannelCode",
						param = new
						{
							deptIdsString = "1",
							channelCode = "1000002$7$0$0"
						},
						isPost = true
					},
					#endregion
					#region 6.发卡复核(404,不推荐使用)
					// 发卡复核/复核
					new baseParamModels()
					{
						nodeName = "node3_6_1",
						url = "/card/accessControl/sendCardCheckAgain",
						param = new
						{
							deviceCode = "1000004"
						},
						isPost = true
					},
					// 发卡复核/同步到设备
					new baseParamModels()
					{
						nodeName = "node3_6_2",
						url = "/card/accessControl/addCardPrivilegeForCheckAgain",
						param = new
						{
							deviceCode = "1000004"
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
							deviceCode = "1000004",
							//isOnlyShowDiff = false,
							pageNum = 1,
							pageSize = 100
						},
						isPost = true
					},
					#endregion
					#region 7.门通道控制(√)
					// 门通道控制/开门
					new baseParamModels()
					{
						nodeName = "node3_7_1",
						url = "/card/accessControl/channelControl/openDoor",
						param = new
						{
							channelCodeList = new string[]
							{
								"1000002$7$0$0",
								"1000004$7$0$0"
							}
						},
						isPost = true
					},
					// 门通道控制/开门
					new baseParamModels()
					{
						nodeName = "node3_7_2",
						url = "/card/accessControl/channelControl/closeDoor",
						param = new
						{
							channelCodeList = new string[]
							{
								"1000002$7$0$0",
								"1000004$7$0$0"
							}
						},
						isPost = true
					},
					// 门通道控制/常开
					new baseParamModels()
					{
						nodeName = "node3_7_3",
						url = "/card/accessControl/channelControl/stayOpen",
						param = new
						{
							channelCodeList = new string[]
							{
								"1000002$7$0$0",
								"1000004$7$0$0"
							}
						},
						isPost = true
					},
					// 门通道控制/常闭
					new baseParamModels()
					{
						nodeName = "node3_7_4",
						url = "/card/accessControl/channelControl/stayClose",
						param = new
						{
							channelCodeList = new string[]
							{
								"1000002$7$0$0",
								"1000004$7$0$0"
							}
						},
						isPost = true
					},
					#endregion
					#region 8.记录查询(√)
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
					#endregion
					#region 9.设备状态日志(√-)
					// 设备状态日志/查询设备状态(无其他参数可查询，添加参数400)
					new baseParamModels()
					{
						nodeName = "node3_9_1",
						url = "/card/accessControl/swingCardRecord/bycondition/combined",
						param = new
						{
							//deviceCode = "1000004",
							//startDate = "2018-12-10 00:00:00",
							//endDate = "2018-12-10 23:59:59",
							pageNum = 1,
							pageSize = 20
						},
						isPost = true
					},
					// 设备状态日志/脱机记录采集(√)
					new baseParamModels()
					{
						nodeName = "node3_9_2",
						url = "/card/accessControl/swingCardRecord/offRecordTime",
						param = new
						{
							//startDate = "2018-12-10 00:00:00",
							//endDate = "2018-12-10 23:59:59",
							//devId = "1000004",
							pageNum = 1,
							pageSize = 20
						},
						isPost = true
					},
					#endregion
					#region 10.服务查询(√)
					// 服务查询/服务查询(√)
					new baseParamModels()
					{
						nodeName = "node3_10_1",
						url = "/card/accessControl/service/getServiceList",
						param = new
						{
							pageNum = 1,
							pageSize = 100
						},
						isPost = true
					},
					// 服务查询/启用服务(√)
					new baseParamModels()
					{
						nodeName = "node3_10_2",
						url = "/card/accessControl/service/enableSlaveService",
						param = new
						{
							serviceId = "6001",
							machineSN = "1"
						},
						isPost = true
					},
					// 服务查询/禁用服务(√)
					new baseParamModels()
					{
						nodeName = "node3_10_3",
						url = "/card/accessControl/service/disableSlaveService",
						param = new
						{
							serviceId = "6001",
							machineSN = "1"
						},
						isPost = true
					},
					// 服务查询/删除服务(√)
					new baseParamModels()
					{
						nodeName = "node3_10_4",
						url = "/card/accessControl/service/deleteSlaveService",
						param = new
						{
							serviceId = "6001",
							machineSN = "1"
						},
						isPost = true
					},
				#endregion
				#endregion
				#region 4.一卡通人员卡片接口(√)
					#region 1.人员管理(√*1)
					// 人员管理/添加人员(√)
					new baseParamModels()
					{
						nodeName = "node4_1_1",
						url = "/card/person",
						param = new
						{
							paperNumber = "320723199504243611",
							name = "张三",
							code = "2333",
							deptId = 2,
							sex = "男",
							birthday = "2010-09-13",
							phone = "15961791569",
							status = "在职",
							paperType = "身份证",
							personIdentityId = -99
						},
						isPost = true
					},
					// 人员管理/批量添加人员(500)
					new baseParamModels()
					{
						nodeName = "node4_1_2",
						url = "/card/person/batch",
						param = new
						{
							namePrefix = "test",
							personCount = 2,
							codePrifix = "test",
							deptId = 1,
							personIdentityId = -99
						},
						isPost = true
					},
					// 人员管理/删除人员(√)
					new baseParamModels()
					{
						nodeName = "node4_1_3",
						url = "/card/person/delete",
						param = new
						{
							personIds = new int[]
							{
								6
							}
						},
						isPost = true
					},
					// 人员管理/修改人员(√)
					new baseParamModels()
					{
						nodeName = "node4_1_4",
						url = "/card/person/update",
						param = new
						{
							paperNumber = "32072319950424361X",
							id = 6,
							name = "张三e",
							code = "2333",
							deptId = 2,
							sex = "男",
							birthday = "2010-09-13",
							phone = "15961791569",
							status = "在职",
							paperType = "身份证",
							personIdentityId = 8
						},
						isPost = true
					},
					// 人员管理/查询人员(√)
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
					// 人员管理/移动部门(√)
					new baseParamModels()
					{
						nodeName = "node4_1_6",
						url = "/card/person/move",
						param = new
						{
							deptId = "1",
							personIds = new int[] {6}
						},
						isPost = true
					},
					#endregion
					#region 2.卡片管理(√)
					// 卡片管理/人员开卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_1",
						url = "/card/card/open/batch",
						param = new
						{
							objectList = new object[] {
								new {
									cardNumber = "A2222222",
									cardType = "0",
									cardStatus = "ACTIVE",
									startDate = "2017-02-23",
									endDate = "2019-02-23",
									cardSubsidy = "0",
									cardCash = "0",
									cardCost = "0",
									cardDeposit = "0",
									cardPassword = getPwd("123456"),
									category = "0",
									subSystems = "1,3,4,5,6",
									personId = 6,
									personName = "张三x"
								}
							}
						},
						isPost = true
					},
					// 卡片管理/激活卡挂失(√)
					new baseParamModels()
					{
						nodeName = "node4_2_2",
						url = "/card/card/lose",
						param = new
						{
							cardIds = new int[] {9}
						},
						isPost = true
					},
					// 卡片管理/激活卡退卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_3",
						url = "/card/card/return",
						param = new
						{
							cardIds = new int[] {7}
						},
						isPost = true
					},
					// 卡片管理/冻结卡解挂(√)
					new baseParamModels()
					{
						nodeName = "node4_2_4",
						url = "/card/card/relieve",
						param = new
						{
							cardIds = new int[] {9}
						},
						isPost = true
					},
					// 卡片管理/冻结卡补卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_5",
						url = "/card/card/renew",
						param = new
						{
							personId = "6",
							newCardNumber = "A12C3454"
						},
						isPost = true
					},
					// 卡片管理/卡片查询(√)
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
					// 卡片管理/单个添加空白卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_7",
						url = "/card/card",
						param = new
						{
							cardNumber = "AA112234",
							cardType = "0",
							category = "0"
						},
						isPost = true
					},
					// 卡片管理/批量添加空白卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_8",
						url = "/card/card/batch",
						param = new
						{
							startNumber = "A1112234",
							endNumber = "A1112236",
							category = "0"
						},
						isPost = true
					},
					// 卡片管理/删除空白卡(√)
					new baseParamModels()
					{
						nodeName = "node4_2_9",
						url = "/card/card/delete",
						param = new
						{
							cardIds = new int[] {2}
						},
						isPost = true
					},
				#endregion
				#endregion
				#region 5.一卡通梯控接口(暂不使用)
					#region 1.梯控管理
					// 梯控管理/添加梯控(√)
					new baseParamModels()
					{
						nodeName = "node5_1_1",
						url = "/card/ecs/elevator",
						param = new
						{
							elevatorCode = "43",
							elevatorName = "电梯1",
							layers = 64,
							startLayer = 1,
							usedLayers = "1~64"
						},
						isPost = true
					},
					// 梯控管理/删除梯控(x:404)
					new baseParamModels()
					{
						nodeName = "node5_1_2",
						url = "/card/ecs/elevator/delete/1",
						param = new
						{
						},
						isPost = true
					},
					// 梯控管理/修改梯控(√)
					new baseParamModels()
					{
						nodeName = "node5_1_3",
						url = "/card/ecs/elevator/update",
						param = new
						{
							id = 1,
							elevatorCode = "433",
							layers = 64,
							startLayer = 1,
							usedLayers = "1~64"
						},
						isPost = true
					},
					// 梯控管理/获取所有梯控(√)
					new baseParamModels()
					{
						nodeName = "node5_1_4",
						url = "/card/ecs/elevator",
						param = new
						{
						},
						isPost = false
					},
					#endregion
					#region 2.梯控授权
					// 梯控授权/查询梯控授权(√)
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
					// 梯控授权/梯控授权(√)
					new baseParamModels()
					{
						nodeName = "node5_2_2",
						url = "/card/ecs/elevator/authorization/update",
						param = new
						{
							authorizationType = "普通",
							cardNumber = "11111111",
							objectList = new object[] {
								new {
									elevatorId = "1",
									elevatorName = "电梯1",
									authorizedLayers = "1,4"
								}
							}
						},
						isPost = true
					},
					// 梯控授权/根据卡号查询梯控授权(404)
					new baseParamModels()
					{
						nodeName = "node5_2_3",
						url = "/card/ecs/elevator/authorization/bycondition/card/11111111",
						param = new
						{
						},
						isPost = true
					},
				#endregion
				#endregion
				#region 6.一卡通系统配置接口(暂不使用)
					#region 1.节假日配置(√)
					// 节假日配置/添加节假日
					new baseParamModels()
					{
						nodeName = "node6_1_1",
						url = "/attendance/holiday",
						param = new
						{
							name = "年休假1",
							type = "SPECIAL",
							startDate = "2015-10-01",
							endDate = "2015-10-07",
							comment = "434",
							everyyear = false
						},
						isPost = true
					},
					// 节假日配置/删除节假日
					new baseParamModels()
					{
						nodeName = "node6_1_2",
						url = "/attendance/holiday/delete",
						param = new
						{
							ids = new int[] {1,2}
						},
						isPost = true
					},
					// 节假日配置/修改节假日
					new baseParamModels()
					{
						nodeName = "node6_1_3",
						url = "/attendance/holiday/update",
						param = new
						{
							id = 2,
							name = "年休假1改",
							type = "SPECIAL",
							startDate = "2015-10-01",
							endDate = "2015-10-07",
							comment = "434",
							everyyear = false
						},
						isPost = true
					},
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
					#endregion
					#region 2.身份配置
					// 身份配置/添加身份(√)
					new baseParamModels()
					{
						nodeName = "node6_2_1",
						url = "/card/person/personidentity",
						param = new
						{
							name = "测试身份1",
							description = "测试身份1",
							isCashRecharge = "1",
							isMachineRecharge = "1"
						},
						isPost = true
					},
					// 身份配置/删除身份(x:500)
					new baseParamModels()
					{
						nodeName = "node6_2_2",
						url = "/card/person/personidentity/delete",
						param = new
						{
							ids = new int[] {9}
						},
						isPost = true
					},
					// 身份配置/修改身份(√)
					new baseParamModels()
					{
						nodeName = "node6_2_3",
						url = "/card/person/personidentity/update",
						param = new
						{
							id = 9,
							name = "测试身份1改",
							description = "测试身份1改"
						},
						isPost = true
					},
					// 身份配置/查询身份(√)
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
				#endregion
				#region 7.一卡通消费接口(√)
					#region 1.营业单位管理(√)
					// 营业单位管理/添加营业单位(√)
					new baseParamModels()
					{
						nodeName = "node7_1_1",
						url = "/card/merchant",
						param = new
						{
							parentId = 1,
							name = "ceshi营业单位"
						},
						isPost = true,
						hasUserId = true
					},
					// 营业单位管理/删除营业单位(√)
					new baseParamModels()
					{
						nodeName = "node7_1_2",
						url = "/card/merchant/delete/5",
						param = new
						{
						},
						isPost = true
					},
					// 营业单位管理/修改营业单位名称(√)
					new baseParamModels()
					{
						nodeName = "node7_1_3",
						url = "/card/merchant/update",
						param = new
						{
							id = 2,
							parentId = 1,
							name = "ceshi营业单位1"
						},
						isPost = true
					},
					// 营业单位管理/查询营业单位(√)
					new baseParamModels()
					{
						nodeName = "node7_1_4",
						url = "/card/merchant/merchantTerminalTree",
						param = new
						{
						},
						isPost = true,
						hasUserId = true
					},
					#endregion
					#region 2.消费设备(√)
					// 消费设备/添加消费设备(√)
					new baseParamModels()
					{
						nodeName = "node7_2_1",
						url = "/card/consumption/terminal",
						param = new
						{
							terminalCode = "3434343545",
							terminalName = "4343",
							merchantId = 1,
							terminalType = "消费机",
							terminalIp = "0.0.0.0",
							terminalPort = "5001",
							communicationMode = "TCP/IP",
							businessTimeId = 2,
							status = "离线"
						},
						isPost = true
					},
					// 消费设备/删除消费设备(√)
					new baseParamModels()
					{
						nodeName = "node7_2_2",
						url = "/card/consumption/terminal/delete",
						param = new
						{
							terminalIds = new int[] {3}
						},
						isPost = true
					},
					// 消费设备/修改消费设备(√)
					new baseParamModels()
					{
						nodeName = "node7_2_3",
						url = "/card/consumption/terminal/update",
						param = new
						{
							terminalCode = "3434343545",
							terminalName = "4343222",
							merchantId = 1,
							terminalType = "消费机",
							terminalIp = "0.0.0.0",
							terminalPort = "5001",
							communicationMode = "TCP/IP",
							businessTimeId = 2,
							status = "离线",
							id = 3
						},
						isPost = true
					},
					// 消费设备/查询消费设备(√)
					new baseParamModels()
					{
						nodeName = "node7_2_4",
						url = "/card/consumption/terminal/bycondition/combined",
						param = new
						{
							pageNum = 1,
							pageSize = 20
						},
						isPost = true,
						hasUserId =true
					},
					#endregion
					#region 3.规则设置(√)
					// 规则设置/添加营业时间段(√)
					new baseParamModels()
					{
						nodeName = "node7_3_1",
						url = "/card/consumption/business_time",
						param = new
						{
							businessTimeName = "测试营业时间段",
							breakfastTimePeroid = "06:00:00~08:00:00",
							lunchTimePeroid = "11:30:00~13:00:00",
							dinnerTimePeroid = "17:30:00~19:00:00",
							supperTimePeroid = "22:00:00~24:00:00"
						},
						isPost = true
					},
					// 规则设置/删除营业时间段(√)
					new baseParamModels()
					{
						nodeName = "node7_3_2",
						url = "/card/consumption/business_time/delete",
						param = new
						{
							businessTimeIds = new int[] {2,3}
						},
						isPost = true
					},
					// 规则设置/修改营业时间段(√)
					new baseParamModels()
					{
						nodeName = "node7_3_3",
						url = "/card/consumption/business_time/update",
						param = new
						{
							businessTimeName = "测试营业时间段改",
							breakfastTimePeroid = "06:00:00~08:00:00",
							lunchTimePeroid = "11:30:00~13:00:00",
							dinnerTimePeroid = "17:30:00~19:00:00",
							supperTimePeroid = "22:00:00~24:00:00",
							id = 2
						},
						isPost = true
					},
					// 规则设置/查询营业时间段(√)
					new baseParamModels()
					{
						nodeName = "node7_3_4",
						url = "/card/consumption/business_time",
						param = new
						{
						},
						isPost = false
					},
					#endregion
					#region 4.充值管理(√)
					// 充值管理/卡片充值(√)
					new baseParamModels()
					{
						nodeName = "node7_4_1",
						url = "/card/card/recharge",
						param = new
						{
							cardNumber = "A12C3454",
							cardCashToRecharge = 20,
							description = "开户充值",
							personId = 6,
							personName = "张三e",
							deptId = 2,
							deptName = "XX校区",
							eventType = "现金充值"
						},
						isPost = true
					},
					// 充值管理/卡片退款(√)
					new baseParamModels()
					{
						nodeName = "node7_4_2",
						url = "/card/card/refund",
						param = new
						{
							cardNumber = "11111111",
							cardCashToRefund = 1,
							description = "离职退款",
							personId = 1,
							personName = "222",
							deptId = 1,
							deptName = "根节点"
						},
						isPost = true
					},
					#endregion
					#region 5.日志查询(√)
					// 日志查询/消费日志(√)
					new baseParamModels()
					{
						nodeName = "node7_5_1",
						url = "/card/consumption/card_consumption_record/bycondition/combined",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							startTime = "2018-03-12 00:00:00",
							endTime = "2018-09-12 00:00:00",
							sortBy = "CREATE_TIME",
							sortOrder = "DESC"
						},
						isPost = true,
						hasUserId = true
					},
					// 日志查询/充值日志(√)
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
					#endregion
					#region 6.报表统计(√)
					// 报表统计/营收收入(√)
					new baseParamModels()
					{
						nodeName = "node7_6_1",
						url = "/card/consumption/statistical_report/merchant",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//startDate = "2018-12-09",
							//endDate = "2018-12-09"
							//merchantIdsString = "1"
						},
						isPost = true,
						hasUserId = true
					},
					// 报表统计/人员消费(√)
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
					// 报表统计/现金交易(√)
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
					#endregion
					#region 7.参数设置(√)
					// 参数设置/补贴参数设置
					new baseParamModels()
					{
						nodeName = "node7_7_1",
						url = "/card/consumption/subsidy_rule/update",
						param = new
						{
							id = 1,
							issueDay = 1,
							subsidyAmount = 600,
							subsidyPattern = "累加"
						},
						isPost = true
					},
					// 参数设置/补贴身份设置
					new baseParamModels()
					{
						nodeName = "node7_7_2",
						url = "/card/person/personIdentities/update",
						param = new
						{
							objectList = new object[]
							{
								new
								{
									id = -99,
									subsidyAmount = 600,
									isCashRecharge = "0",
									isMachineRecharge = "1"
								},
								new
								{
									id = 0,
									subsidyAmount = 600,
									isCashRecharge = "0",
									isMachineRecharge = "1"
								},
								new
								{
									id = 1,
									subsidyAmount = 600,
									isCashRecharge = "0",
									isMachineRecharge = "1"
								},
							}
						},
						isPost = true
					},
					// 参数设置/补贴参数是启用
					new baseParamModels()
					{
						nodeName = "node7_7_3",
						url = "/card/consumption/subsidy_rule/initialization/1",
						param = new
						{
						},
						isPost = false
					},
					// 参数设置/补贴参数不启用
					new baseParamModels()
					{
						nodeName = "node7_7_4",
						url = "/card/consumption/subsidy_rule/uninitialization/1",
						param = new
						{
						},
						isPost = false
					},
					// 参数设置/消费参数修改
					new baseParamModels()
					{
						nodeName = "node7_7_5",
						url = "/card/consumption/consumption_rule/update",
						param = new
						{
							id = 2,
							consumptionQuotaDaily = 100,
							consumptionQuotaTimely = 50,
							consumptionTimeLimitDaily = 5,
							minAmount = 5
						},
						isPost = true
					},
					// 参数设置/充值参数修改
					new baseParamModels()
					{
						nodeName = "node7_7_6",
						url = "/card/setting/update",
						param = new
						{
							objectList = new object[]
							{
								new
								{
									id = 1,
									propertyValue = "YES",
									propertyName = "isSubsidyRefundable"    // 补贴金额
								},
								new
								{
									id = 2,
									propertyValue = "1000.00",
									propertyName = "maxRechargeAmount"  // 最大充值金额
								},
								new
								{
									id = 3,
									propertyValue = "YES",
									propertyName = "isRechargeTicketPrintable"  // 是否打印小票
								},
								new
								{
									id = 4,
									propertyValue = "100000.00",
									propertyName = "maxAccountAmount"   // 账户最大金额
								}
							}
						},
						isPost = true
					},
					#endregion
					#region 8.消费授权(√)
					// 消费授权/增加授权(√)
					new baseParamModels()
					{
						nodeName = "node7_8_1",
						url = "/card/consumption/terminal/authorization",
						param = new
						{
							cardNumbers = new string[] { "A12C3454" },
							terminalIds = new string[] { "2" }
						},
						isPost = true
					},
					// 消费授权/删除授权(√)
					new baseParamModels()
					{
						nodeName = "node7_8_2",
						url = "/card/consumption/terminal/authorization/delete",
						param = new
						{
							cardNumbers = new string[] { "11111111" }
						},
						isPost = true
					},
					// 消费授权/修改授权(√)
					new baseParamModels()
					{
						nodeName = "node7_8_3",
						url = "/card/consumption/terminal/authorization/update",
						param = new
						{
							cardNumber = "11111111",
							terminalIds = new string[] {"1"}
						},
						isPost = true
					},
					// 消费授权/查询授权(400)
					new baseParamModels()
					{
						nodeName = "node7_8_4",
						url = "/card/consumption/terminal/card/authorizable",
						param = new
						{
							pageNum = 1,
							pageSize = 20,
							//isAuthorized = "否"
						},
						isPost = true
					},
					#endregion
				#endregion
				#region 8.一卡通巡更接口(暂不使用)
					#region 1.巡更点设置
					// 巡更点设置/增加巡更点
					new baseParamModels()
					{
						nodeName = "node8_1_1",
						url = "/card/patrol/point",
						param = new
						{
							cardReaderId = "20",
							name = "测试巡更点1",
							pointCode = "1000036$7$0$0$1",
							pointType = 1
						},
						isPost = true
					},
					// 巡更点设置/修改巡更点
					new baseParamModels()
					{
						nodeName = "node8_1_2",
						url = "/card/patrol/point/update",
						param = new
						{
							id = "2",
							name = "测试巡更点1"
						},
						isPost = true
					},
					// 巡更点设置/删除巡更点
					new baseParamModels()
					{
						nodeName = "node8_1_3",
						url = "/card/patrol/point/delete/batch",
						param = new
						{
							patrolPointIds = new int[] {11,12}
						},
						isPost = true
					},
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
					#endregion
					#region 2.班组设置
					// 班组设置/增加班组
					new baseParamModels()
					{
						nodeName = "node8_2_1",
						url = "/card/patrol/classGroup",
						param = new
						{
							name = "测试班组",
							memo = "备注1",
							details = new object[]
							{
								new
								{
									id = "",
									classGroupId = "",
									personId = "4",
									personName = "",
									personCode = "",
									deptName = ""
								},
								new
								{
									id = "",
									classGroupId = "",
									personId = "1",
									personName = "",
									personCode = "",
									deptName = ""
								}
							}
						},
						isPost = true
					},
					// 班组设置/修改班组
					new baseParamModels()
					{
						nodeName = "node8_2_2",
						url = "/card/patrol/classGroup/update",
						param = new
						{
							id = "1",
							name = "新班组1",
							memo = "备注1",
							addPersonIds = new string[] {"1","3","5"},
							deletePersonIds = new string[] {"2","4","6"}
						},
						isPost = true
					},
					// 班组设置/删除班组
					new baseParamModels()
					{
						nodeName = "node8_2_3",
						url = "/card/patrol/classGroup/delete/batch",
						param = new
						{
							patrolClassGroupIds = new int[] {1,2,3}
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
					#endregion
					#region 3.线路设置
					// 线路设置/增加线路
					new baseParamModels()
					{
						nodeName = "node8_3_1",
						url = "/card/patrol/route",
						param = new
						{
							name = "测试路线A",
							duration = "5",
							direction = "1",
							details = new object[] {
								new {
									pointSeq = "1",
									pointCode = "1000009$7$0$0$1",
									intervalTime = "0",
									deviationTime = "1"

								},
								new {
									pointSeq = "2",
									pointCode = "1000009$7$0$0$2",
									intervalTime = "5",
									deviationTime = "1"
								}
							}
						},
						isPost = true
					},
					// 线路设置/修改线路
					new baseParamModels()
					{
						nodeName = "node8_3_2",
						url = "/card/patrol/route/update",
						param = new
						{
							id = 2,
							name = "测试路线A",
							duration = "5",
							direction = "1",
							addDetails = new object[] {},
							deleteDetails = new object[] {},
							modifyDetails = new object[] {
								new {
									id = "1",
									pointSeq = "1",
									pointCode = "1000009$7$0$0$1",
									intervalTime = "0",
									deviationTime = "1",
									pointName = "66",
									routeId = 2
								},
								new {
									id = "2",
									pointSeq = "2",
									pointCode = "1000009$7$0$0$2",
									intervalTime = "5",
									deviationTime = "1",
									pointName = "66",
									routeId = 2
								}
							}
						},
						isPost = true
					},
					// 线路设置/删除线路
					new baseParamModels()
					{
						nodeName = "node8_3_3",
						url = "/card/patrol/route/delete/batch",
						param = new
						{
							patrolRouteIds = new int[] {1,2}
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
					// 线路设置/查询线路列表
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
					#endregion
					#region 4.排班设置
					// 排班设置/增加排班
					new baseParamModels()
					{
						nodeName = "node8_4_1",
						url = "/card/patrol/orderClass",
						param = new
						{
							id = "12",
							personId = "2",
							classGroupId = "3",
							routeId = "3",
							startTimeStr = "2017-03-15",
							holiday = "1",
							endTimeStr = "2018-03-31",
							excludeType = "2",
							excludeDate = "1,2,3,4,5",
							details = new object[] {
								new {
									timeIntervalSeq = "1",
									name = "时段1",
									startTime = "22:55",
									endTime = "23:00"

								}
							}
						},
						isPost = true
					},
					// 排班设置/修改排班
					new baseParamModels()
					{
						nodeName = "node8_4_2",
						url = "/card/patrol/orderClass/update",
						param = new
						{
							id = "12",
							personId = "2",
							classGroupId = "3",
							routeId = "3",
							startTimeStr = "2017-03-15",
							holiday = "1",
							endTimeStr = "2018-03-31",
							excludeType = "2",
							excludeDate = "1,2,3,4,5",
							addDetails = new object[] {
								new {
									timeIntervalSeq = "1",
									name = "时段1",
									startTime = "22:55",
									endTime = "23:00",
									orderClassId = "12"
								}
							},
							modifyDetails = new object[] {},
							deleteDetails = new object[] {}
						},
						isPost = true
					},
					// 排班设置/删除排班
					new baseParamModels()
					{
						nodeName = "node8_4_3",
						url = "/card/patrol/orderClass/delete/batch",
						param = new
						{
							patrolOrderClassIds = new int[] {1,2}
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
					#endregion
					#region 5.记录查询
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
					#endregion
					#region 6.报表统计
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
				#endregion
			};
			return modelList;
		}
	}
}
