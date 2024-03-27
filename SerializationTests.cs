//Testing the serialization and deserialization works
using Assignment_3;
using Assignment_3.Utility;
using Assignment_3.ProblemDomain;
namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private SLL users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            SLL deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            Assert.IsTrue(users.Count() == deserializedUsers.Count());
            // Compare contents
            for (int i = 0; i < users.Count(); i++)
                {
                    User expected = users.GetValue(i);
                    User actual = deserializedUsers.GetValue(i);

                    Assert.AreEqual(expected.Id, actual.Id);
                    Assert.AreEqual(expected.Name, actual.Name);
                    Assert.AreEqual(expected.Email, actual.Email);
                    Assert.AreEqual(expected.Password, actual.Password);
                }
            }
    }
}