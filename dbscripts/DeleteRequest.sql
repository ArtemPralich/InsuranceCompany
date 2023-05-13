/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [Id]
      ,[DateOfStart]
      ,[DateOfEnd]
      ,[AgentId]
      ,[InsuranceRateId]
      ,[InsuranceStatusId]
      ,[Cost]
      ,[BasePayment]
      ,[UnitPayment]
      ,[Coefficient]
      ,[IsReadyDocuments]
  FROM [InsuranceCompany1].[dbo].[InsuranceRequest]


	delete from [InsuranceCompany1].[dbo].AnswerValue where InsuranceRequestId = '65ADAB47-48E5-405F-903E-08DB52B54836';
	delete from [InsuranceCompany1].[dbo].AnswerValue where InsuranceRequestId = '3E50DCED-F472-4469-0174-08DB52B640E7';
	delete from [InsuranceCompany1].[dbo].InsuredPersons where InsuranceRequestId = '65ADAB47-48E5-405F-903E-08DB52B54836';
	delete from [InsuranceCompany1].[dbo].InsuredPersons where InsuranceRequestId = '3E50DCED-F472-4469-0174-08DB52B640E7';
  
  delete from [InsuranceCompany1].[dbo].[InsuranceRequest] where InsuranceStatusId is null;