create database MusicFM
use MusicFM
create table Users
(
	HoTen nvarchar(50) not null,
	NamSinh nvarchar(50) not null,
	Email nvarchar(50) primary key,
	SoDienThoai nvarchar(15) not null,
	MatKhau nvarchar(50) not null
)
