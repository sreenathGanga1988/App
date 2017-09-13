SET IDENTITY_INSERT [dbo].[OdooDetails] ON
INSERT INTO [dbo].[OdooDetails] ([OdooDetailID], [Server], [PortNum], [UserId], [Password], [DataBasename], [IsActive], [StoreID]) VALUES (1, N'192.168.1.73', 5432, N'odoo', N'at123', N'eth-aug26', 1, 1)
SET IDENTITY_INSERT [dbo].[OdooDetails] OFF
