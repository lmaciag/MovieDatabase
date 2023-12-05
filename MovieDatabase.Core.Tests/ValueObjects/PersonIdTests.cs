using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class PersonIdTests
{
    [TestCase("baa9e409-09cc-4c5c-a0f3-881254dacdfc")]
    [TestCase("1f46a54f-061d-4ea3-afd7-935dfa1d4e97")]
    [TestCase("d1b39cd8-36f1-4284-bfed-a1af15bfd818")]
    [TestCase("61e5b21e-b96b-4944-aec6-576d26331783")]
    [TestCase("ad69f99d-ea2a-4109-a0ef-d493e5da4428")]
    [TestCase("29145696-a9bb-4949-9540-c501929d0caf")]
    [TestCase("def1b762-649a-4c62-82f7-1c185adb0e1b")]
    [TestCase("fc27811f-830e-4134-b7f0-451d997ba689")]
    [TestCase("59217199-0fd6-43e6-979d-ee6855039862")]
    [TestCase("8784437c-2cf5-4d0a-b6c6-50b38d0acfca")]
    [TestCase("7602585a-ed5b-4ce3-a2fa-467c50119770")]
    [TestCase("4115cfc1-eedb-44e0-adc0-d6e6374c7aba")]
    [TestCase("8fda72db-18be-48c7-b24c-345fbb63e25a")]
    [TestCase("bfafbeaf-c95a-4f4d-b181-60d2f1918404")]
    [TestCase("167563fb-fc5e-405b-9063-ec00474368b8")]
    [TestCase("675e6713-d595-4805-9f98-af2281410d63")]
    [TestCase("f9c2643f-e0b8-453d-9bca-c0b7c2395f08")]
    [TestCase("4618a471-b1fb-4107-b5d1-64678d09a644")]
    [TestCase("58c17033-1783-44fb-a729-40b3551ef41d")]
    [TestCase("c0f19d68-07ae-4102-90e6-c5d2daf16c8b")]
    [TestCase("1e8e21e1-066e-49af-ab8c-ca16ec83c5e8")]
    [TestCase("b3ef982b-5483-432a-9fe9-28d98bb1e608")]
    [TestCase("48163032-7691-46ad-a5d7-76fa678eff7b")]
    [TestCase("f8ed4681-c8c4-411f-8bb0-b739a04f5ed0")]
    [TestCase("6ebfdc9f-3201-47e3-b916-cc336fc0b694")]
    [TestCase("f5972f5e-bc44-4f5f-81e5-8f8e1667808d")]
    [TestCase("a948d02e-23ba-4c2f-a5fa-8d3cc95e9abe")]
    [TestCase("f2107d85-f8fc-4538-80f8-c9374cd889eb")]
    [TestCase("9d621692-d21c-45c4-b74c-3c6d0d6cf136")]
    [TestCase("e8562d77-e1ae-463d-b00b-7751cace266f")]
    [TestCase("0be78332-21b4-4b57-a253-fa629875f436")]
    [TestCase("6e51812f-10f4-4d63-895d-4f18a51d7794")]
    [TestCase("ae8e8c46-b49d-4977-bbd1-012a264267ab")]
    [TestCase("313af172-9d0b-400b-a285-fe55adae47b4")]
    [TestCase("9a2a168e-ca4c-4e05-9ffd-9c2a9601d854")]
    [TestCase("51528f65-5a62-4047-8131-17216b40a0ac")]
    [TestCase("91bf8f31-9f7e-4a59-84c1-5e3b748edc0f")]
    [TestCase("fc9c87e2-aff4-46ad-9be9-3e6058f1d175")]
    [TestCase("bfabf3df-3c19-4563-ad80-519a1d70cd23")]
    [TestCase("1f2fe4f3-cc07-4a6a-bba1-fbf96e3a1bb4")]
    [TestCase("cfaf033f-ec0d-43eb-be45-139d567e6d7f")]
    [TestCase("32fee6d7-ec78-41a3-9f07-f8fbcd1a9bc3")]
    [TestCase("55489d1c-2bb9-4206-b7a4-428b83dea99f")]
    [TestCase("a73ff6d4-2c6b-49ac-8406-3bd6bdf9c0c7")]
    [TestCase("6beabb6c-74d1-4ec4-81d9-52d85c51aee1")]
    [TestCase("fadfd3e1-d2ba-4614-820f-62b907e3511c")]
    [TestCase("7311e146-63fb-4673-80a2-fa080e5cb737")]
    [TestCase("17fa71ac-9175-4881-80b5-aa026dfe16c6")]
    [TestCase("9a01c2da-2368-4bc0-8e86-eb64425a6d18")]
    [TestCase("a5f25842-2d28-4278-b3c8-d38512cadc69")]
    public void ProperGuidsShouldCreatePersonId(string id)
    {
        var parsedId = Guid.Parse(id);
        
        var personId= new PersonId(parsedId);
        
        personId.Value.ShouldBe(parsedId);
    }
    
    [Test]
    public void EmptyGuidShouldThrowInvalidPersonIdException()
    {
        Should.Throw<InvalidPersonIdException>(() => new PersonId(Guid.Empty));
    }
}