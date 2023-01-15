SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([id], [name], [username], [password], [is_admin], [phone], [email], [address]) 
VALUES (1, 'rumy', 'admin', 'admin', 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
