using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RivneBloodTransfusionCenter.Data.EfDbContext;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;

namespace RivneBloodTransfusionCenter.Data.SeedData
{
    public class PreConfigured
    {
        public static async Task SeedRoles(RoleManager<DbRole> roleManager)
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new DbRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin",
                    });
                    await roleManager.CreateAsync(new DbRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Donor",
                    });
                    await roleManager.CreateAsync(new DbRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Recipient"
                    });
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static async Task SeedUsers(UserManager<DbUser> userManager, EfContext context)
        {

            try
            {
                if (!context.AdminProfiles.Any())
                {
                    AdminProfile adminProfile = new ()
                    {
                        Id = Guid.NewGuid().ToString(),
                    };
                    DbUser user1 = new ()
                    {
                        Id = adminProfile.Id,
                        UserName = "Admin",
                        Name = "Taras",
                        SerName="Hruhorovich",
                        LastName="Shevchenko",
                        Email = "admin@gmail.com",
                        AdminProfile = adminProfile
                    };

                    await userManager.CreateAsync(user1, "Qwerty-1");
                    await userManager.AddToRoleAsync(user1, "Admin");

                    await context.AdminProfiles.AddAsync(adminProfile);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public static async Task SeedBloodTypes(EfContext context)
        {

            try
            {
                if (!context.BloodTypes.Any())
                {
                    BloodType bloodType1 = new()
                    {
                        Name = "Перша позитивна, O(I)Rh(+)"
                    };
                    BloodType bloodType2 = new()
                    {
                        Name = "Перша негативна, O(I)Rh(-)"
                    };
                    BloodType bloodType3 = new()
                    {
                        Name = "Друга позитивна, A(II)Rh(+)"
                    };
                    BloodType bloodType4 = new()
                    {
                        Name = "Друга негативна, A(II)Rh(-)"
                    };
                    BloodType bloodType5 = new()
                    {
                        Name = "Третя позитивна, B(III)Rh(+)"
                    };
                    BloodType bloodType6 = new()
                    {
                        Name = "Третя негативна, B(III)Rh(-)"
                    };
                    BloodType bloodType7 = new()
                    {
                        Name = "Четверта позитивна, AB(IV)Rh(+)"
                    };
                    BloodType bloodType8 = new()
                    {
                        Name = "Четверта негативна, AB(IV)Rh(-)"
                    };
                    BloodType bloodType9 = new()
                    {
                        Name = "Будь-яка"
                    };

                    await context.BloodTypes.AddRangeAsync(bloodType1, bloodType2, bloodType3, bloodType4, bloodType5, bloodType6, bloodType7, bloodType8, bloodType9);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static async Task SeedDonationTypes(EfContext context)
        {

            try
            {
                if (!context.DonationTypes.Any())
                {
                    DonationType donationType1 = new()
                    {
                        Name = "Цільна кров"
                    };
                    DonationType donationType2 = new()
                    {
                        Name = "Тромбоцити"
                    };
                    DonationType donationType3 = new()
                    {
                        Name = "Плазма"
                    };
                    DonationType donationType4 = new()
                    {
                        Name = "Гранулоцити"
                    };


                    await context.DonationTypes.AddRangeAsync(donationType1, donationType2, donationType3, donationType4);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static async Task SeedSicknesses(EfContext context)
        {

            try
            {
                if (!context.Sicknesses.Any())
                {
                    var sicknessList = new List<Sickness>
                    {
                      new Sickness { Name = "B-лімфобластна лімфома" },
                new Sickness { Name = "HELLP-синдром" },
                new Sickness { Name = "АL-амілоїдоз" },
                new Sickness { Name = "Абсцес черевної порожнини" },
                new Sickness { Name = "Аденоїди" },
                new Sickness { Name = "Аденокарцинома" },
                new Sickness { Name = "Аденокарцинома шлунка" },
                new Sickness { Name = "Аденома" },
                new Sickness { Name = "Амілоїдоз нирок" },
                new Sickness { Name = "Ампутація" },
                new Sickness { Name = "Анапластична астроцитома" },
                new Sickness { Name = "Анапластична багатоклітинна лімфома" },
                new Sickness { Name = "Анастамоз" },
                new Sickness { Name = "Аневризма аорти" },
                new Sickness { Name = "Аневризма серця" },
                new Sickness { Name = "Аневризма судин головного мозку" },
                new Sickness { Name = "Анемія" },
                new Sickness { Name = "Аномалія Ебштейна" },
                new Sickness { Name = "Аортокоронарне шунтування (АКШ)" },
                new Sickness { Name = "Аплазія кісткового мозку" },
                new Sickness { Name = "Апластична анемія" },
                new Sickness { Name = "Аритмія серця" },
                new Sickness { Name = "Артроз плечового суглоба" },
                new Sickness { Name = "Асфіксія (ядуха, задуха)" },
                new Sickness { Name = "Атеросклероз" },
                new Sickness { Name = "Атеросклероз судин нижніх кінцівок" },
                new Sickness { Name = "Атеросклеротичний кардіосклероз" },
                new Sickness { Name = "Атрезія легеневої артерії" },
                new Sickness { Name = "Аутоімунний гемоліз" },
                new Sickness { Name = "Бронхообструктивний синдром" },
                new Sickness { Name = "Бульозна емфізема легень" },
                new Sickness { Name = "Вади серця" },
                new Sickness { Name = "Варикозне розширення вен стравоходу" },
                new Sickness { Name = "В-великоклітинна лімфома" },
                new Sickness { Name = "Вертебральний больовий синдром" },
                new Sickness { Name = "Вивих стегна" },
                new Sickness { Name = "Викидень" },
                new Sickness { Name = "Виразка дванадцятипалої кишки" },
                new Sickness { Name = "Виразка шлунка" },
                new Sickness { Name = "Виразкова хвороба" },
                new Sickness { Name = "Високодиференційована аденокарцинома" },
                new Sickness { Name = "Відмирання клітин мозку" },
                new Sickness { Name = "ВІЛ (Вірус імунодефіциту людини)" },
                new Sickness { Name = "Внутрішньоутробна пневмонія" },
                new Sickness { Name = "Внутрішня кровотеча" },
                new Sickness { Name = "Волосатоклітинний лейкоз" },
                new Sickness { Name = "Вроджена вада нирки" },
                new Sickness { Name = "Вроджена кишкова непрохідність" },
                new Sickness { Name = "Вроджений порок серця" },
                new Sickness { Name = "Вроджені вади серця" },
                new Sickness { Name = "Вторинна анемія" },
                new Sickness { Name = "Газова гангрена (анаеробна гангрена або клостридіальний міонекроз)" },
                new Sickness { Name = "Гангліонейробластома" },
                new Sickness { Name = "Гангрена" },
                new Sickness { Name = "Гангрена Фурньє" },
                new Sickness { Name = "Гастрит дванадцятипалої кишки" },
                new Sickness { Name = "Гастроінтестинальна стромальна пухлина (ГІСО, англ. GIST)" },
                new Sickness { Name = "Гемангіома" },
                new Sickness { Name = "Гемолітико-уремічний синдром" },
                new Sickness { Name = "Гемолітична анемія" },
                new Sickness { Name = "Гемолітична хвороба новонародженого" },
                new Sickness { Name = "Геморагічний інсульт (крововилив у мозок, внутрішньомозковий крововилив)" },
                new Sickness { Name = "Геморагічний шок" },
                new Sickness { Name = "Гемофагоцитарний лімфогістіоцитоз, або гемофагоцитарний синдром" },
                new Sickness { Name = "Гемофілія" },
                new Sickness { Name = "Гепатит" },
                new Sickness { Name = "Гепатит В" },
                new Sickness { Name = "Гепатит С" },
                new Sickness { Name = "Гепатобластома" },
                new Sickness { Name = "Гепатобластома печінки" },
                new Sickness { Name = "Гепаторенальний синдром" },
                new Sickness { Name = "Гепатоцелюлярна карцинома" },
                new Sickness { Name = "Герміногенні пухлини" },
                new Sickness { Name = "Гермінома головного мозку" },
                new Sickness { Name = "Гігантська солітарна пухлина легень" },
                new Sickness { Name = "Гіперплазія ендометрія" },
                new Sickness { Name = "Гіпертрофія аденоїдів" },
                new Sickness { Name = "Гіпоплазія кісткового мозку" },
                new Sickness { Name = "Гістеректомія" },
                new Sickness { Name = "Гістіоцитоз з клітин Лангерганса (ГКЛ, лангергансовоклітинний гістіоцитоз та ін.)" },
                new Sickness { Name = "Гліома" },
                new Sickness { Name = "Гліосаркома" },
                new Sickness { Name = "Гломерулонефрит (також клубочковий нефрит чи хвороба Брайта)" },
                new Sickness { Name = "Гонадобластома" },
                new Sickness { Name = "Гостра ішемія кишківника" },
                new Sickness { Name = "Гостра крововтрата" },
                new Sickness { Name = "Гостра лейкемія" },
                new Sickness { Name = "Гостра лімфобластна лейкемія" },
                new Sickness { Name = "Гостре пошкодження нирок" },
                new Sickness { Name = "Гострий лімфобластний лейкоз" },
                new Sickness { Name = "Гострий лімфоцитарний лейкоз" },
                new Sickness { Name = "Гострий мегакаріобластний лейкоз" },
                new Sickness { Name = "Гострий мієлобластний лейкоз" },
                new Sickness { Name = "Гострий мієлоїдний лейкоз" },
                new Sickness { Name = "Гострий мієломоноцитарний лейкоз" },
                new Sickness { Name = "Гострий монобластний лейкоз" },
                new Sickness { Name = "Гострий моноцитарний лейкоз" },
                new Sickness { Name = "Гострий промієлоцитарний лейкоз" },
                new Sickness { Name = "Гострі лейкози" },
                new Sickness { Name = "Гранулематоз Вегенера" },
                new Sickness { Name = "ДВЗ-синдром (дисеміноване внутрішньосудинне згортання, коагулопатія споживання, тромбогеморагічний синдром)" },
                new Sickness { Name = "Дефект міжпередсердної перегородки" },
                new Sickness { Name = "Дивертикул прямої кишки" },
                new Sickness { Name = "Дизеритропоетична анемія" },
                new Sickness { Name = "Дисгермінома яєчника" },
                new Sickness { Name = "Дисплазія колінного суглоба" },
                new Sickness { Name = "Диссекція аорти" },
                new Sickness { Name = "Дитячий церебральний параліч (ДЦП)" },
                new Sickness { Name = "Дифузний кардіосклероз" },
                new Sickness { Name = "Діабетична кома" },
                new Sickness { Name = "Діабетична нефропатія" },
                new Sickness { Name = "Діабетична стопа" },
                new Sickness { Name = "Діагноз уточнюється" },
                new Sickness { Name = "Для поповнення запасів банку крові" },
                new Sickness { Name = "Електроопік" },
                new Sickness { Name = "Ембріональна пухлина" },
                new Sickness { Name = "Ендопротезування колінного суглоба" },
                new Sickness { Name = "Ендопротезування тазостегнового (кульшового) суглоба" },
                new Sickness { Name = "Ентероколіт" },
                new Sickness { Name = "Енцефаліт" },
                new Sickness { Name = "Епендимома" },
                new Sickness { Name = "Епітеліоїдна гемангіоендотеліома" },
                new Sickness { Name = "Ерозивний езофагіт" },
                new Sickness { Name = "Естезіонейробластома" },
                new Sickness { Name = "Єдиний шлуночок серця (ЄЖС)" },
                new Sickness { Name = "Жовчнокам'яна хвороба" },
                new Sickness { Name = "Забій" },
                new Sickness { Name = "Заміна мітрального клапана серця" },
                new Sickness { Name = "Заміна серцевого клапана" },
                new Sickness { Name = "Ідіопатична тромбоцитопенічна пурпура" },
                new Sickness { Name = "Ідіопатичний мієлофіброз" },
                new Sickness { Name = "Імунодефіцит (також імунна недостатність або імунодефіцитний стан)" },
                new Sickness { Name = "Інсульт" },
                new Sickness { Name = "Інфантильний міофіброматоз" },
                new Sickness { Name = "Інфантильний фіброматоз" },
                new Sickness { Name = "Інфаркт міокарда" },
                new Sickness { Name = "Інфекційний ендокардит" },
                new Sickness { Name = "Ішемічна хвороба серця" },
                new Sickness { Name = "Канцероматоз черевної порожнини" },
                new Sickness { Name = "Карцинома (Рак)" },
                new Sickness { Name = "Кататравма" },
                new Sickness { Name = "Кесарів розтин" },
                new Sickness { Name = "Кишкова кровотеча" },
                new Sickness { Name = "Кишкова непрохідність" },
                new Sickness { Name = "Кір" },
                new Sickness { Name = "Кіста яєчника" },
                new Sickness { Name = "Кістома яєчника" },
                new Sickness { Name = "Коагулопатія" },
                new Sickness { Name = "Коарктація аорти" },
                new Sickness { Name = "Коксартроз" },
                new Sickness { Name = "Коровникова хвороба" },
                new Sickness { Name = "Коронaрна недостaтність" },
                new Sickness { Name = "Коронавірусна хвороба Covid-2019" },
                new Sickness { Name = "Коронарне шунтування" },
                new Sickness { Name = "Краш-синдром (Травматичний токсикоз, або Синдром тривалого здавлювання, Синдром Байуотерса, м'язово-нирковий синдром)" },
                new Sickness { Name = "Крововилив (геморагія, екстравазат)" },
                new Sickness { Name = "Крововилив у мозок" },
                new Sickness { Name = "Кровотеча" },
                new Sickness { Name = "Кровотеча при вагітності" },
                new Sickness { Name = "Кровотечі при пологах" },
                new Sickness { Name = "Ксантома" },
                new Sickness { Name = "Легенева гіпертензія" },
                new Sickness { Name = "Лейкемія" },
                new Sickness { Name = "Лейкоз" },
                new Sickness { Name = "Лейкоцитоз" },
                new Sickness { Name = "Лептоспіроз" },
                new Sickness { Name = "Лімфогранулематоз (хвороба Годжкіна, або Ходжкіна, злоя́кісна гранульома)" },
                new Sickness { Name = "Лімфолейкоз" },
                new Sickness { Name = "Лімфома" },
                new Sickness { Name = "Лімфома Беркітта" },
                new Sickness { Name = "Лімфома Ходжкіна" },
                new Sickness { Name = "Лімфома шлунка" },
                new Sickness { Name = "Мале коло кровообігу" },
                new Sickness { Name = "Мастопатія" },
                new Sickness { Name = "Маткова кровотеча" },
                new Sickness { Name = "Медіастиніт" },
                new Sickness { Name = "Медулобластома" },
                new Sickness { Name = "Мезіальний темпоральний склероз" },
                new Sickness { Name = "Меланома" },
                new Sickness { Name = "Менінгіт" },
                new Sickness { Name = "Менінгоенцефаліт" },
                new Sickness { Name = "Метроррагія, або маткова кровотеча" },
                new Sickness { Name = "Міастенія" },
                new Sickness { Name = "Мієлодиспластичний синдром" },
                new Sickness { Name = "Мієлолейкоз" },
                new Sickness { Name = "Мієлома" },
                new Sickness { Name = "Мієлопроліферативні захворювання" },
                new Sickness { Name = "Мієлофіброз" },
                new Sickness { Name = "Мікрокарцинома" },
                new Sickness { Name = "Міксома лівого передсердя" },
                new Sickness { Name = "Міома" },
                new Sickness { Name = "Мітрально-аортальний порок" },
                new Sickness { Name = "Множинна мієлома" },
                new Sickness { Name = "Муковісцидоз" },
                new Sickness { Name = "Мультилокулярна (багатокамерна) кістозна нефрома" },
                new Sickness { Name = "Недиференційований рак шлунка" },
                new Sickness { Name = "Недоношена дитина" },
                new Sickness { Name = "Недостатність аортального клапана" },
                new Sickness { Name = "Недостатність мітрального (двостулкового) клапана (мітральна недостатність)" },
                new Sickness { Name = "Нейробластома" },
                new Sickness { Name = "Нейросаркома (нейрофібросаркома)" },
                new Sickness { Name = "Нейрофіброматоз" },
                new Sickness { Name = "Некроз" },
                new Sickness { Name = "Неонатальний сепсис" },
                new Sickness { Name = "Неспецифічний виразковий коліт (Виразковий коліт, НВК)" },
                new Sickness { Name = "Нефректомія" },
                new Sickness { Name = "Нефробластома (пухлина Вільмса)" },
                new Sickness { Name = "Нефротичний синдром" },
                new Sickness { Name = "Неходжкінські лімфоми" },
                new Sickness { Name = "Низькодиференційований рак" },
                new Sickness { Name = "Ниркова недостатність (уремія)" },
                new Sickness { Name = "Нирковий мультикістоз" },
                new Sickness { Name = "Олігодактилія" },
                new Sickness { Name = "Онкологічні захворювання" },
                new Sickness { Name = "Опік" },
                new Sickness { Name = "Опікова хвороба" },
                new Sickness { Name = "Опущення і випадіння внутрішніх статевих органів (пролапс тазових органів)" },
                new Sickness { Name = "Остеобластокластома" },
                new Sickness { Name = "Остеомієлофіброз (мієлолейкоз остеосклеротичний)" },
                new Sickness { Name = "Остеопороз" },
                new Sickness { Name = "Остеосаркома" },
                new Sickness { Name = "Отруєння або інтоксикація" },
                new Sickness { Name = "Отруєння грибами" },
                new Sickness { Name = "Панкреатит" },
                new Sickness { Name = "Панкреонекроз" },
                new Sickness { Name = "Панцитопенія" },
                new Sickness { Name = "Парагангліома" },
                new Sickness { Name = "Пароксизмальна нічна гемоглобінурія" },
                new Sickness { Name = "Пахвинна грижа" },
                new Sickness { Name = "Передлежання плаценти" },
                new Sickness { Name = "Передчасні пологи" },
                new Sickness { Name = "Перелом" },
                new Sickness { Name = "Перелом великої гомілкової кістки" },
                new Sickness { Name = "Перелом шийки стегна" },
                new Sickness { Name = "Переломи проксимальної плечової кістки" },
                new Sickness { Name = "Переломи стегнової кістки" },
                new Sickness { Name = "Перитоніт" },
                new Sickness { Name = "Перфорація кишечника" },
                new Sickness { Name = "Перфорація порожнистого органа" },
                new Sickness { Name = "Печінкова недостатність" },
                new Sickness { Name = "Підвищений білірубін" },
                new Sickness { Name = "Пілоростеноз" },
                new Sickness { Name = "Плазмоклітинна мієлома" },
                new Sickness { Name = "Пневмонія" },
                new Sickness { Name = "Повна обструкція дванадцятипалої кишки" },
                new Sickness { Name = "Повна форма атріовентрикулярної комунікації" },
                new Sickness { Name = "Полікістоз нирок" },
                new Sickness { Name = "Поліорганна недостатність" },
                new Sickness { Name = "Поліп шлунка" },
                new Sickness { Name = "Поліпи прямої кишки" },
                new Sickness { Name = "Політравма" },
                new Sickness { Name = "Помірно диференційована аденокарцинома" },
                new Sickness { Name = "Порок серця" },
                new Sickness { Name = "Портальна гіпертензія" },
                new Sickness { Name = "Примітивна нейроектодермальна пухлина (ПНЕП)" },
                new Sickness { Name = "Пролапс мітрального клапана" },
                new Sickness { Name = "Псевдоміксома черевної порожнини" },
                new Sickness { Name = "Псевдотуморозний панкреатит" },
                new Sickness { Name = "Пухлина" },
                new Sickness { Name = "Пухлина великого дуоденального сосочка" },
                new Sickness { Name = "Пухлина заочеревинного простору" },
                new Sickness { Name = "Пухлина кишечника" },
                new Sickness { Name = "Пухлина очеревини" },
                new Sickness { Name = "Пухлини головного мозку" },
                new Sickness { Name = "Пухлини яєчка" },
                new Sickness { Name = "Рабдоміосаркома" },
                new Sickness { Name = "Рак гортані" },
                new Sickness { Name = "Рак кишечника" },
                new Sickness { Name = "Рак кишківника" },
                new Sickness { Name = "Рак кісток" },
                new Sickness { Name = "Рак крові" },
                new Sickness { Name = "Рак легенів" },
                new Sickness { Name = "Рак молочної залози" },
                new Sickness { Name = "Рак нирки" },
                new Sickness { Name = "Рак ободової кишки" },
                new Sickness { Name = "Рак передміхурової залози" },
                new Sickness { Name = "Рак печінки" },
                new Sickness { Name = "Рак підшлункової залози" },
                new Sickness { Name = "Рак простати" },
                new Sickness { Name = "Рак прямої кишки" },
                new Sickness { Name = "Рак сечового міхура" },
                new Sickness { Name = "Рак сигмовидної кишки" },
                new Sickness { Name = "Рак сліпої кишки" },
                new Sickness { Name = "Рак стравоходу" },
                new Sickness { Name = "Рак товстого кишечника" },
                new Sickness { Name = "Рак товстої кишки" },
                new Sickness { Name = "Рак шийки матки" },
                new Sickness { Name = "Рак шлунка" },
                new Sickness { Name = "Рак яєчників" },
                new Sickness { Name = "Ревматична хвороба серця" },
                new Sickness { Name = "Резекція" },
                new Sickness { Name = "Резекція шлунка" },
                new Sickness { Name = "Ретинобластома" },
                new Sickness { Name = "Рефрактерна анемія" },
                new Sickness { Name = "Розрив стравоходу" },
                new Sickness { Name = "Розсіяний склероз" },
                new Sickness { Name = "Розшарування аорти" },
                new Sickness { Name = "Ротова інфекція" },
                new Sickness { Name = "Саркома" },
                new Sickness { Name = "Саркома печінки" },
                new Sickness { Name = "Саркома Юінга (дифузна ендотеліома або ендотеліальна мієлома)" },
                new Sickness { Name = "Саркоми м’яких тканин" },
                new Sickness { Name = "Семіноми яєчок" },
                new Sickness { Name = "Сепсис" },
                new Sickness { Name = "Септопластика" },
                new Sickness { Name = "Серцева недостатність" },
                new Sickness { Name = "Сечокам'яна хвороба" },
                new Sickness { Name = "Синдром Віскотта-Олдріча" },
                new Sickness { Name = "Синдром Гієна-Барре" },
                new Sickness { Name = "Синдром Гієна-Барре-Ландрі" },
                new Sickness { Name = "Синдром Ді Георга (синдром Ді Джорджа, синдром Ді Джорджі)" },
                new Sickness { Name = "Синдром Казабаха-Мерріта" },
                new Sickness { Name = "Синдром Лаєлла або токсичний епідермальний некроліз" },
                new Sickness { Name = "Синдром Леріша" },
                new Sickness { Name = "Синдром Мелорі-Вейса" },
                new Sickness { Name = "Системний васкуліт" },
                new Sickness { Name = "Системний червоний вовчак (хвороба Лібмана-Сакса)" },
                new Sickness { Name = "Спастична диплегія" },
                new Sickness { Name = "Спленектомія" },
                new Sickness { Name = "Стеноз аортального клапана (Аортальний стеноз)" },
                new Sickness { Name = "Стеноз мітрального клапана" },
                new Sickness { Name = "Стеноз стравоходу" },
                new Sickness { Name = "Стеноз хребетного каналу" },
                new Sickness { Name = "Страбізм" },
                new Sickness { Name = "Субарахноїдальний крововилив (САК, спонтанний або первинний)" },
                new Sickness { Name = "Сублейкемічний мієлоз" },
                new Sickness { Name = "Тератобластома" },
                new Sickness { Name = "Термічний опік" },
                new Sickness { Name = "Тетрада Фалло" },
                new Sickness { Name = "Тотально аномальний дренаж легеневих вен" },
                new Sickness { Name = "Травматичний остеомієліт" },
                new Sickness { Name = "Трансплантація печінки" },
                new Sickness { Name = "Транспозиція магістральних судин (ТМС)" },
                new Sickness { Name = "Тромбастенія Гланцмана" },
                new Sickness { Name = "Тромбоемболія легеневої артерії (ТЕЛА)" },
                new Sickness { Name = "Тромбоз" },
                new Sickness { Name = "Тромбоз глибоких вен нижніх кінцівок" },
                new Sickness { Name = "Тромбофілія" },
                new Sickness { Name = "Тромбофлебіт" },
                new Sickness { Name = "Тромбоцитопенія" },
                new Sickness { Name = "Трофобластична хвороба вагітності" },
                new Sickness { Name = "Туберкульоз легень" },
                new Sickness { Name = "Фіброма" },
                new Sickness { Name = "Фіброміома матки" },
                new Sickness { Name = "Фібросаркома" },
                new Sickness { Name = "Фізична травма" },
                new Sickness { Name = "Флегмона" },
                new Sickness { Name = "Хвороба Вільсона-Коновалова" },
                new Sickness { Name = "Хвороба Крона" },
                new Sickness { Name = "Хвороба Рандю-Ослера" },
                new Sickness { Name = "Хірургічна операція" },
                new Sickness { Name = "Холангіокарцинома" },
                new Sickness { Name = "Холангіоцелюлярна карцинома" },
                new Sickness { Name = "Хондросаркома" },
                new Sickness { Name = "Хоріоамніоніт" },
                new Sickness { Name = "Хронічна гранулематозна хвороба" },
                new Sickness { Name = "Хронічна лімфоїдна лейкемія" },
                new Sickness { Name = "Хронічна мієлоїдна лейкемія" },
                new Sickness { Name = "Хронічна ниркова недостатність" },
                new Sickness { Name = "Хронічний лімфолейкоз" },
                new Sickness { Name = "Хронічний лімфоцитарний лейкоз" },
                new Sickness { Name = "Хронічний мієлоїдний лейкоз" },
                new Sickness { Name = "Хронічний мієлолейкоз" },
                new Sickness { Name = "Хронічний мієломоноцитарний лейкоз" },
                new Sickness { Name = "Цироз печінки" },
                new Sickness { Name = "Цукровий діабет" },
                new Sickness { Name = "Черепно-мозкова травма" },
                new Sickness { Name = "Шлунково-кишкова кровотеча" },
                new Sickness { Name = "Шунтування серця" },
                new Sickness { Name = "Ювенільний мієломоноцитарний лейкоз" },
                new Sickness { Name = "Юнацький епіфізеоліз головки стегнової кістки" }
                            };
                    await context.Sicknesses.AddRangeAsync(sicknessList);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
