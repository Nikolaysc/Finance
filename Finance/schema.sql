create table if not exists [categories](
	[category_id] integer primary key autoincrement,
	[name] varchar(256)
);

create table if not exists [users](
	[user_id] integer primary key autoincrement,
	[login] varchar(256),
	[password] char(60)
);

create table if not exists [event](
	[event_id] integer primary key autoincrement,
	[user_id] integer,
	[date] text,
	[amount] integer,
	[category_id] integer,
	[name] text,

	FOREIGN KEY([user_id]) REFERENCES [users]([user_id]),
	FOREIGN KEY([category_id]) REFERENCES [categories]([category_id])
);

create table if not exists [event_categories] (
	[event_id] integer,
	[category_id] integer,

	PRIMARY KEY([event_id], [category_id])
);