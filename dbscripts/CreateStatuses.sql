/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
Insert into [InsuranceCompany1].[dbo].[InsuranceStatus] ([Id],[Color], [Status]) values ('75e6ce8f-74fc-43ba-8b11-ca02724b7f8d','#EDD1F8','Создано клиентом')
Insert into [InsuranceCompany1].[dbo].[InsuranceStatus] ([Id],[Color], [Status]) values ('9EAC0D43-CEB1-404C-85E2-D7C9303DFCD8','#f73939','Возвращено с ошибкой')

Update [InsuranceCompany1].[dbo].[InsuranceStatus] set IsDisabledForms = 1 where Id = 'B74A9704-FF2C-4992-80B5-F22905091835' or Id = '8CD43F71-1D6A-4A45-8974-6A4D9F6749ED'

SELECT TOP (1000) [Id]
      ,[Status]
      ,[Color]
      ,[IsDisabledDocuments]
      ,[IsDisabledForms]
  FROM [InsuranceCompany1].[dbo].[InsuranceStatus]

  Insert into [InsuranceCompany1].[dbo].[InsuranceStatus] ([Id],[Color], [Status], IsDisabledForms) values ('8CD43F71-1D6A-4A45-8974-6A4D9F6749ED','#a0fa5e','Подписано', 1)
