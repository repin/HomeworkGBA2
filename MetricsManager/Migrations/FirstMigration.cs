using FluentMigrator;

namespace MetricsManager.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {

        /// <summary>
        /// Выполняется в случае применения миграции
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Up()
        {
            Create.Table("agentinfo")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("agentaddress").AsString()
                .WithColumn("enable").AsBoolean();
        }

        /// <summary>
        /// Выполняется в случае отката миграции
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Down()
        {
            Delete.Table("agentinfo");
        }


    }
}
