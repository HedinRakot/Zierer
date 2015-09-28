








	SET IDENTITY_INSERT [ProfiCraftsman].[dbo].[PERMISSION] ON;
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 11 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(11, 'Orders', 'Auftrag' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,11 ,getdate() ,getdate(), 'b882b325a4c32027bb7a3589209866b9');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Auftrag'
		WHERE ID = 11
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 19 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(19, 'AdditionalCostTypes', 'Nebenkostenarten' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,19 ,getdate() ,getdate(), 'd95707be29939982dd2ad5ca01d391f2');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Nebenkostenarten'
		WHERE ID = 19
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 20 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(20, 'Rates', 'Stundensätze' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,20 ,getdate() ,getdate(), '53200e57c4ccd64378017b367b5d3b4e');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Stundensätze'
		WHERE ID = 20
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 21 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(21, 'CustomProducts', 'Sonderleistungen' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,21 ,getdate() ,getdate(), 'dc6a907c14c45daa22113e2e865b2af5');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Sonderleistungen'
		WHERE ID = 21
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 12 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(12, 'Invoices', 'Rechnung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,12 ,getdate() ,getdate(), 'ef914082afe6874a9bab2b30c864407b');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Rechnung'
		WHERE ID = 12
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 22 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(22, 'ProceedsAccounts', 'Erlöskonten' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,22 ,getdate() ,getdate(), 'ade1db7d430c93e81950649d0c592883');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Erlöskonten'
		WHERE ID = 22
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 4 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(4, 'Materials', 'Material' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,4 ,getdate() ,getdate(), '34b8a5e9772cd73daba26c68a209127f');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Material'
		WHERE ID = 4
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 23 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(23, 'ForeignProducts', 'Fremdleistung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,23 ,getdate() ,getdate(), 'e318de089dcf578594fad92a4d07f5f8');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Fremdleistung'
		WHERE ID = 23
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 24 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(24, 'SocialTaxes', 'Soziale Abgaben' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,24 ,getdate() ,getdate(), '3282fbcac3fe69dd9f4662941765bad7');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Soziale Abgaben'
		WHERE ID = 24
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 16 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(16, 'Autos', 'Auto' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,16 ,getdate() ,getdate(), '953c63b37f046860033bb652a63c24e6');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Auto'
		WHERE ID = 16
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 1 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(1, 'Permission', 'Berechtigung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,1 ,getdate() ,getdate(), 'ec308451c1d095c528cfa3c009ea7235');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Berechtigung'
		WHERE ID = 1
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 15 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(15, 'JobPositions', 'Dienststelle' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,15 ,getdate() ,getdate(), '7177ff6aafad58b0656fca6e31b41601');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Dienststelle'
		WHERE ID = 15
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 2 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(2, 'Role', 'Rolle' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,2 ,getdate() ,getdate(), 'ab35e84a215f0f711ed629c2abb9efa0');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Rolle'
		WHERE ID = 2
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 17 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(17, 'Employees', 'Mitarbeiter' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,17 ,getdate() ,getdate(), '821588896b793f28e7b607f4f43ee80b');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Mitarbeiter'
		WHERE ID = 17
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 13 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(13, 'InvoiceStornos', 'Storno Rechnung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,13 ,getdate() ,getdate(), 'c6b90c3c2e476767ef8ca0b4e5cf1d4d');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Storno Rechnung'
		WHERE ID = 13
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 3 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(3, 'User', 'Benutzer' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,3 ,getdate() ,getdate(), 'f0f421418433ba3cb592238eb7e51441');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Benutzer'
		WHERE ID = 3
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 5 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(5, 'AdditionalCosts', 'Sonstige Kosten' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,5 ,getdate() ,getdate(), '2cb17e69baebaeed67190ad729bb2601');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Sonstige Kosten'
		WHERE ID = 5
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 6 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(6, 'Taxes', 'Umsatzsteuer' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,6 ,getdate() ,getdate(), '291dd475d0224126a68550d7c406f3b1');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Umsatzsteuer'
		WHERE ID = 6
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 7 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(7, 'TransportProducts', 'Transport-Leistung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,7 ,getdate() ,getdate(), 'a38d461d24e96016feb6b6d14db03fcc');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Transport-Leistung'
		WHERE ID = 7
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 8 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(8, 'Customers', 'Kunde' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,8 ,getdate() ,getdate(), '77c77478b552f1977cad320741ba92a5');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Kunde'
		WHERE ID = 8
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 25 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(25, 'Absences', 'Abwesenheiten' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,25 ,getdate() ,getdate(), '4323c8ddee2766bdacb349a9eb050d4b');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Abwesenheiten'
		WHERE ID = 25
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 14 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(14, 'TransportOrders', 'Transport Auftrag' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,14 ,getdate() ,getdate(), '9be1cd563f04d329bc30a6918cfb1205');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Transport Auftrag'
		WHERE ID = 14
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 9 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(9, 'ProductTypes', 'Leistungsart' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,9 ,getdate() ,getdate(), 'b80a98836bb3f1f478d8093ef8f4a998');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Leistungsart'
		WHERE ID = 9
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 26 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(26, 'NotProductiveWorkHours', 'Arbeitszeiten' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,26 ,getdate() ,getdate(), '626b0927d175af4546e18d0224e72a56');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Arbeitszeiten'
		WHERE ID = 26
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 18 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(18, 'Instruments', 'Werkzeug' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,18 ,getdate() ,getdate(), '06f05548148f447f31ea2b875415842a');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Werkzeug'
		WHERE ID = 18
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 27 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(27, 'OwnProducts', 'Eigenleistung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,27 ,getdate() ,getdate(), '487a6cf65eb7f0a29db8c423aa58202c');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Eigenleistung'
		WHERE ID = 27
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 10 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(10, 'Products', 'Leistung' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,10 ,getdate() ,getdate(), '5cd6a063c51df65aa0d61bbfd9882874');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Leistung'
		WHERE ID = 10
	END
	
	IF NOT EXISTS (SELECT ID FROM [ProfiCraftsman].[dbo].[PERMISSION] WHERE ID = 28 )
	BEGIN
		INSERT INTO [ProfiCraftsman].[dbo].[PERMISSION] ([Id], [Name], [Description], [CreateDate], [ChangeDate], [DeleteDate])
		VALUES(28, 'Interests', 'Zinsen' ,GETDATE() ,GETDATE() ,NULL);
		INSERT INTO [ProfiCraftsman].dbo.ROLE_PERMISSION_RSP(RoleId ,PermissionId ,CreateDate ,ChangeDate, [Key]) 
		VALUES (1 ,28 ,getdate() ,getdate(), '4619445188371e1cfe34593d015c1b98');
	END
	ELSE
	BEGIN
		UPDATE [ProfiCraftsman].[dbo].[PERMISSION]
		SET [DESCRIPTION] = 'Zinsen'
		WHERE ID = 28
	END
	SET IDENTITY_INSERT [ProfiCraftsman].[dbo].[PERMISSION] OFF;

