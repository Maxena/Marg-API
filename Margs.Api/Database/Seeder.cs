using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;

namespace Margs.Api.Database;

public class Seeder
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly PgDbContext _pg;

    public Seeder(IDateTimeProvider dateTimeProvider, PgDbContext pg)
    {
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        _pg = pg ?? throw new ArgumentNullException(nameof(pg));
    }

    public async Task SeedRoles()
    {
        #region Seeding Roles

        var roles = new List<Role>
        {
            new()
            {
                Name = "Admin",
                Description = "Admin Role",
                CreatedAt = _dateTimeProvider.UtcNow,
            },
            new()
            {
                Name = "Mohandes",
                Description = "Mohandes Role just for Engineers",
                CreatedAt = _dateTimeProvider.UtcNow,
            },
            new()
            {
                Name = "Samali",
                Description = "samali role just for amirhossein and mamali",
                CreatedAt = _dateTimeProvider.UtcNow
            },
            new()
            {
                Name = "Seyed",
                Description = "seyed role just for amir marei",
                CreatedAt = _dateTimeProvider.UtcNow
            },
            new()
            {
                Name = "Navid Abadi",
                Description = "navid abadi role just for soltan navid abadi",
                CreatedAt = _dateTimeProvider.UtcNow
            }
        };

        await _pg.Roles.AddRangeAsync(roles);

        #endregion

        #region Seeding Provinces

        var provinces = new List<Province>
        {
            new()
            {
                Id = 1,
                Name = "آذربایجان شرقی",
                Slug = "آذربایجان-شرقی"
            },
            new()
            {
                Id = 2,
                Name = "آذربایجان غربی",
                Slug = "آذربایجان-غربی"
            },
            new()
            {
                Id = 3,
                Name = "اردبیل",
                Slug = "اردبیل"
            },
            new()
            {
                Id = 4,
                Name = "اصفهان",
                Slug = "اصفهان"
            },
            new()
            {
                Id = 5,
                Name = "البرز",
                Slug = "البرز"
            },
            new()
            {
                Id = 6,
                Name = "ایلام",
                Slug = "ایلام"
            },
            new()
            {
                Id = 7,
                Name = "بوشهر",
                Slug = "بوشهر"
            },
            new()
            {
                Id = 8,
                Name = "تهران",
                Slug = "تهران"
            },
            new()
            {
                Id = 9,
                Name = "چهارمحال و بختیاری",
                Slug = "چهارمحال-بختیاری"
            },
            new()
            {
                Id = 10,
                Name = "خراسان جنوبی",
                Slug = "خراسان-جنوبی"
            },
            new()
            {
                Id = 11,
                Name = "خراسان رضوی",
                Slug = "خراسان-رضوی"
            },
            new()
            {
                Id = 12,
                Name = "خراسان شمالی",
                Slug = "خراسان-شمالی"
            },
            new()
            {
                Id = 13,
                Name = "خوزستان",
                Slug = "خوزستان"
            },
            new()
            {
                Id = 14,
                Name = "زنجان",
                Slug = "زنجان"
            },
            new()
            {
                Id = 15,
                Name = "سمنان",
                Slug = "سمنان"
            },
            new()
            {
                Id = 16,
                Name = "سیستان و بلوچستان",
                Slug = "سیستان-بلوچستان"
            },
            new()
            {
                Id = 17,
                Name = "فارس",
                Slug = "فارس"
            },
            new()
            {
                Id = 18,
                Name = "قزوین",
                Slug = "قزوین"
            },
            new()
            {
                Id = 19,
                Name = "قم",
                Slug = "قم"
            },
            new()
            {
                Id = 20,
                Name = "کردستان",
                Slug = "کردستان"
            },
            new()
            {
                Id = 21,
                Name = "کرمان",
                Slug = "کرمان"
            },
            new()
            {
                Id = 22,
                Name = "کرمانشاه",
                Slug = "کرمانشاه"
            },
            new()
            {
                Id = 23,
                Name = "کهگیلویه و بویراحمد",
                Slug = "کهگیلویه-بویراحمد"
            },
            new()
            {
                Id = 24,
                Name = "گلستان",
                Slug = "گلستان"
            },
            new()
            {
                Id = 25,
                Name = "لرستان",
                Slug = "لرستان"
            },
            new()
            {
                Id = 26,
                Name = "گیلان",
                Slug = "گیلان"
            },
            new()
            {
                Id = 27,
                Name = "مازندران",
                Slug = "مازندران"
            },
            new()
            {
                Id = 28,
                Name = "مرکزی",
                Slug = "مرکزی"
            },
            new()
            {
                Id = 29,
                Name = "هرمزگان",
                Slug = "هرمزگان"
            },
            new()
            {
                Id = 30,
                Name = "همدان",
                Slug = "همدان"
            },
            new()
            {
                Id = 31,
                Name = "یزد",
                Slug = "یزد"
            }
        };

        await _pg.Provinces.AddRangeAsync(provinces);

        #endregion

        #region Seeding Cities

        var cities = new List<City>
        {
            new()
            {
                Id = 1,
                Name = "اسکو",
                Slug = "اسکو",
                ProvinceId = 1
            },
            new()
            {
                Id = 2,
                Name = "اهر",
                Slug = "اهر",
                ProvinceId = 1
            },
            new()
            {
                Id = 3,
                Name = "ایلخچی",
                Slug = "ایلخچی",
                ProvinceId = 1
            },
            new()
            {
                Id = 4,
                Name = "آبش احمد",
                Slug = "آبش-احمد",
                ProvinceId = 1
            },
            new()
            {
                Id = 5,
                Name = "آذرشهر",
                Slug = "آذرشهر",
                ProvinceId = 1
            },
            new()
            {
                Id = 6,
                Name = "آقکند",
                Slug = "آقکند",
                ProvinceId = 1
            },
            new()
            {
                Id = 7,
                Name = "باسمنج",
                Slug = "باسمنج",
                ProvinceId = 1
            },
            new()
            {
                Id = 8,
                Name = "بخشایش",
                Slug = "بخشایش",
                ProvinceId = 1
            },
            new()
            {
                Id = 9,
                Name = "بستان آباد",
                Slug = "بستان-آباد",
                ProvinceId = 1
            },
            new()
            {
                Id = 10,
                Name = "بناب",
                Slug = "بناب",
                ProvinceId = 1
            },
            new()
            {
                Id = 11,
                Name = "بناب جدید",
                Slug = "بناب-جدید",
                ProvinceId = 1
            },
            new()
            {
                Id = 12,
                Name = "تبریز",
                Slug = "تبریز",
                ProvinceId = 1
            },
            new()
            {
                Id = 13,
                Name = "ترک",
                Slug = "ترک",
                ProvinceId = 1
            },
            new()
            {
                Id = 14,
                Name = "ترکمانچای",
                Slug = "ترکمانچای",
                ProvinceId = 1
            },
            new()
            {
                Id = 15,
                Name = "تسوج",
                Slug = "تسوج",
                ProvinceId = 1
            },
            new()
            {
                Id = 16,
                Name = "تیکمه داش",
                Slug = "تیکمه-داش",
                ProvinceId = 1
            },
            new()
            {
                Id = 17,
                Name = "جلفا",
                Slug = "جلفا",
                ProvinceId = 1
            },
            new()
            {
                Id = 18,
                Name = "خاروانا",
                Slug = "خاروانا",
                ProvinceId = 1
            },
            new()
            {
                Id = 19,
                Name = "خامنه",
                Slug = "خامنه",
                ProvinceId = 1
            },
            new()
            {
                Id = 20,
                Name = "خراجو",
                Slug = "خراجو",
                ProvinceId = 1
            },
            new()
            {
                Id = 21,
                Name = "خسروشهر",
                Slug = "خسروشهر",
                ProvinceId = 1
            },
            new()
            {
                Id = 22,
                Name = "خضرلو",
                Slug = "خضرلو",
                ProvinceId = 1
            },
            new()
            {
                Id = 23,
                Name = "خمارلو",
                Slug = "خمارلو",
                ProvinceId = 1
            },
            new()
            {
                Id = 24,
                Name = "خواجه",
                Slug = "خواجه",
                ProvinceId = 1
            },
            new()
            {
                Id = 25,
                Name = "دوزدوزان",
                Slug = "دوزدوزان",
                ProvinceId = 1
            },
            new()
            {
                Id = 26,
                Name = "زرنق",
                Slug = "زرنق",
                ProvinceId = 1
            },
            new()
            {
                Id = 27,
                Name = "زنوز",
                Slug = "زنوز",
                ProvinceId = 1
            },
            new()
            {
                Id = 28,
                Name = "سراب",
                Slug = "سراب",
                ProvinceId = 1
            },
            new()
            {
                Id = 29,
                Name = "سردرود",
                Slug = "سردرود",
                ProvinceId = 1
            },
            new()
            {
                Id = 30,
                Name = "سهند",
                Slug = "سهند",
                ProvinceId = 1
            },
            new()
            {
                Id = 31,
                Name = "سیس",
                Slug = "سیس",
                ProvinceId = 1
            },
            new()
            {
                Id = 32,
                Name = "سیه رود",
                Slug = "سیه-رود",
                ProvinceId = 1
            },
            new()
            {
                Id = 33,
                Name = "شبستر",
                Slug = "شبستر",
                ProvinceId = 1
            },
            new()
            {
                Id = 34,
                Name = "شربیان",
                Slug = "شربیان",
                ProvinceId = 1
            },
            new()
            {
                Id = 35,
                Name = "شرفخانه",
                Slug = "شرفخانه",
                ProvinceId = 1
            },
            new()
            {
                Id = 36,
                Name = "شندآباد",
                Slug = "شندآباد",
                ProvinceId = 1
            },
            new()
            {
                Id = 37,
                Name = "صوفیان",
                Slug = "صوفیان",
                ProvinceId = 1
            },
            new()
            {
                Id = 38,
                Name = "عجب شیر",
                Slug = "عجب-شیر",
                ProvinceId = 1
            },
            new()
            {
                Id = 39,
                Name = "قره آغاج",
                Slug = "قره-آغاج",
                ProvinceId = 1
            },
            new()
            {
                Id = 40,
                Name = "کشکسرای",
                Slug = "کشکسرای",
                ProvinceId = 1
            },
            new()
            {
                Id = 41,
                Name = "کلوانق",
                Slug = "کلوانق",
                ProvinceId = 1
            },
            new()
            {
                Id = 42,
                Name = "کلیبر",
                Slug = "کلیبر",
                ProvinceId = 1
            },
            new()
            {
                Id = 43,
                Name = "کوزه کنان",
                Slug = "کوزه-کنان",
                ProvinceId = 1
            },
            new()
            {
                Id = 44,
                Name = "گوگان",
                Slug = "گوگان",
                ProvinceId = 1
            },
            new()
            {
                Id = 45,
                Name = "لیلان",
                Slug = "لیلان",
                ProvinceId = 1
            },
            new()
            {
                Id = 46,
                Name = "مراغه",
                Slug = "مراغه",
                ProvinceId = 1
            },
            new()
            {
                Id = 47,
                Name = "مرند",
                Slug = "مرند",
                ProvinceId = 1
            },
            new()
            {
                Id = 48,
                Name = "ملکان",
                Slug = "ملکان",
                ProvinceId = 1
            },
            new()
            {
                Id = 49,
                Name = "ملک کیان",
                Slug = "ملک-کیان",
                ProvinceId = 1
            },
            new()
            {
                Id = 50,
                Name = "ممقان",
                Slug = "ممقان",
                ProvinceId = 1
            },
            new()
            {
                Id = 51,
                Name = "مهربان",
                Slug = "مهربان",
                ProvinceId = 1
            },
            new()
            {
                Id = 52,
                Name = "میانه",
                Slug = "میانه",
                ProvinceId = 1
            },
            new()
            {
                Id = 53,
                Name = "نظرکهریزی",
                Slug = "نظرکهریزی",
                ProvinceId = 1
            },
            new()
            {
                Id = 54,
                Name = "هادی شهر",
                Slug = "هادی-شهر",
                ProvinceId = 1
            },
            new()
            {
                Id = 55,
                Name = "هرگلان",
                Slug = "هرگلان",
                ProvinceId = 1
            },
            new()
            {
                Id = 56,
                Name = "هریس",
                Slug = "هریس",
                ProvinceId = 1
            },
            new()
            {
                Id = 57,
                Name = "هشترود",
                Slug = "هشترود",
                ProvinceId = 1
            },
            new()
            {
                Id = 58,
                Name = "هوراند",
                Slug = "هوراند",
                ProvinceId = 1
            },
            new()
            {
                Id = 59,
                Name = "وایقان",
                Slug = "وایقان",
                ProvinceId = 1
            },
            new()
            {
                Id = 60,
                Name = "ورزقان",
                Slug = "ورزقان",
                ProvinceId = 1
            },
            new()
            {
                Id = 61,
                Name = "یامچی",
                Slug = "یامچی",
                ProvinceId = 1
            },
            new()
            {
                Id = 62,
                Name = "ارومیه",
                Slug = "ارومیه",
                ProvinceId = 2
            },
            new()
            {
                Id = 63,
                Name = "اشنویه",
                Slug = "اشنویه",
                ProvinceId = 2
            },
            new()
            {
                Id = 64,
                Name = "ایواوغلی",
                Slug = "ایواوغلی",
                ProvinceId = 2
            },
            new()
            {
                Id = 65,
                Name = "آواجیق",
                Slug = "آواجیق",
                ProvinceId = 2
            },
            new()
            {
                Id = 66,
                Name = "باروق",
                Slug = "باروق",
                ProvinceId = 2
            },
            new()
            {
                Id = 67,
                Name = "بازرگان",
                Slug = "بازرگان",
                ProvinceId = 2
            },
            new()
            {
                Id = 68,
                Name = "بوکان",
                Slug = "بوکان",
                ProvinceId = 2
            },
            new()
            {
                Id = 69,
                Name = "پلدشت",
                Slug = "پلدشت",
                ProvinceId = 2
            },
            new()
            {
                Id = 70,
                Name = "پیرانشهر",
                Slug = "پیرانشهر",
                ProvinceId = 2
            },
            new()
            {
                Id = 71,
                Name = "تازه شهر",
                Slug = "تازه-شهر",
                ProvinceId = 2
            },
            new()
            {
                Id = 72,
                Name = "تکاب",
                Slug = "تکاب",
                ProvinceId = 2
            },
            new()
            {
                Id = 73,
                Name = "چهاربرج",
                Slug = "چهاربرج",
                ProvinceId = 2
            },
            new()
            {
                Id = 74,
                Name = "خوی",
                Slug = "خوی",
                ProvinceId = 2
            },
            new()
            {
                Id = 75,
                Name = "دیزج دیز",
                Slug = "دیزج-دیز",
                ProvinceId = 2
            },
            new()
            {
                Id = 76,
                Name = "ربط",
                Slug = "ربط",
                ProvinceId = 2
            },
            new()
            {
                Id = 77,
                Name = "سردشت",
                Slug = "آذربایجان-غربی-سردشت",
                ProvinceId = 2
            },
            new()
            {
                Id = 78,
                Name = "سرو",
                Slug = "سرو",
                ProvinceId = 2
            },
            new()
            {
                Id = 79,
                Name = "سلماس",
                Slug = "سلماس",
                ProvinceId = 2
            },
            new()
            {
                Id = 80,
                Name = "سیلوانه",
                Slug = "سیلوانه",
                ProvinceId = 2
            },
            new()
            {
                Id = 81,
                Name = "سیمینه",
                Slug = "سیمینه",
                ProvinceId = 2
            },
            new()
            {
                Id = 82,
                Name = "سیه چشمه",
                Slug = "سیه-چشمه",
                ProvinceId = 2
            },
            new()
            {
                Id = 83,
                Name = "شاهین دژ",
                Slug = "شاهین-دژ",
                ProvinceId = 2
            },
            new()
            {
                Id = 84,
                Name = "شوط",
                Slug = "شوط",
                ProvinceId = 2
            },
            new()
            {
                Id = 85,
                Name = "فیرورق",
                Slug = "فیرورق",
                ProvinceId = 2
            },
            new()
            {
                Id = 86,
                Name = "قره ضیاءالدین",
                Slug = "قره-ضیاءالدین",
                ProvinceId = 2
            },
            new()
            {
                Id = 87,
                Name = "قطور",
                Slug = "قطور",
                ProvinceId = 2
            },
            new()
            {
                Id = 88,
                Name = "قوشچی",
                Slug = "قوشچی",
                ProvinceId = 2
            },
            new()
            {
                Id = 89,
                Name = "کشاورز",
                Slug = "کشاورز",
                ProvinceId = 2
            },
            new()
            {
                Id = 90,
                Name = "گردکشانه",
                Slug = "گردکشانه",
                ProvinceId = 2
            },
            new()
            {
                Id = 91,
                Name = "ماکو",
                Slug = "ماکو",
                ProvinceId = 2
            },
            new()
            {
                Id = 92,
                Name = "محمدیار",
                Slug = "محمدیار",
                ProvinceId = 2
            },
            new()
            {
                Id = 93,
                Name = "محمودآباد",
                Slug = "آذربایجان-غربی-محمودآباد",
                ProvinceId = 2
            },
            new()
            {
                Id = 94,
                Name = "مهاباد",
                Slug = "آذربایجان-غربی-مهاباد",
                ProvinceId = 2
            },
            new()
            {
                Id = 95,
                Name = "میاندوآب",
                Slug = "میاندوآب",
                ProvinceId = 2
            },
            new()
            {
                Id = 96,
                Name = "میرآباد",
                Slug = "میرآباد",
                ProvinceId = 2
            },
            new()
            {
                Id = 97,
                Name = "نالوس",
                Slug = "نالوس",
                ProvinceId = 2
            },
            new()
            {
                Id = 98,
                Name = "نقده",
                Slug = "نقده",
                ProvinceId = 2
            },
            new()
            {
                Id = 99,
                Name = "نوشین",
                Slug = "نوشین",
                ProvinceId = 2
            },
            new()
            {
                Id = 100,
                Name = "اردبیل",
                Slug = "اردبیل",
                ProvinceId = 3
            },
            new()
            {
                Id = 101,
                Name = "اصلاندوز",
                Slug = "اصلاندوز",
                ProvinceId = 3
            },
            new()
            {
                Id = 102,
                Name = "آبی بیگلو",
                Slug = "آبی-بیگلو",
                ProvinceId = 3
            },
            new()
            {
                Id = 103,
                Name = "بیله سوار",
                Slug = "بیله-سوار",
                ProvinceId = 3
            },
            new()
            {
                Id = 104,
                Name = "پارس آباد",
                Slug = "پارس-آباد",
                ProvinceId = 3
            },
            new()
            {
                Id = 105,
                Name = "تازه کند",
                Slug = "تازه-کند",
                ProvinceId = 3
            },
            new()
            {
                Id = 106,
                Name = "تازه کندانگوت",
                Slug = "تازه-کندانگوت",
                ProvinceId = 3
            },
            new()
            {
                Id = 107,
                Name = "جعفرآباد",
                Slug = "جعفرآباد",
                ProvinceId = 3
            },
            new()
            {
                Id = 108,
                Name = "خلخال",
                Slug = "خلخال",
                ProvinceId = 3
            },
            new()
            {
                Id = 109,
                Name = "رضی",
                Slug = "رضی",
                ProvinceId = 3
            },
            new()
            {
                Id = 110,
                Name = "سرعین",
                Slug = "سرعین",
                ProvinceId = 3
            },
            new()
            {
                Id = 111,
                Name = "عنبران",
                Slug = "عنبران",
                ProvinceId = 3
            },
            new()
            {
                Id = 112,
                Name = "فخرآباد",
                Slug = "فخرآباد",
                ProvinceId = 3
            },
            new()
            {
                Id = 113,
                Name = "کلور",
                Slug = "کلور",
                ProvinceId = 3
            },
            new()
            {
                Id = 114,
                Name = "کوراییم",
                Slug = "کوراییم",
                ProvinceId = 3
            },
            new()
            {
                Id = 115,
                Name = "گرمی",
                Slug = "گرمی",
                ProvinceId = 3
            },
            new()
            {
                Id = 116,
                Name = "گیوی",
                Slug = "گیوی",
                ProvinceId = 3
            },
            new()
            {
                Id = 117,
                Name = "لاهرود",
                Slug = "لاهرود",
                ProvinceId = 3
            },
            new()
            {
                Id = 118,
                Name = "مشگین شهر",
                Slug = "مشگین-شهر",
                ProvinceId = 3
            },
            new()
            {
                Id = 119,
                Name = "نمین",
                Slug = "نمین",
                ProvinceId = 3
            },
            new()
            {
                Id = 120,
                Name = "نیر",
                Slug = "اردبیل-نیر",
                ProvinceId = 3
            },
            new()
            {
                Id = 121,
                Name = "هشتجین",
                Slug = "هشتجین",
                ProvinceId = 3
            },
            new()
            {
                Id = 122,
                Name = "هیر",
                Slug = "هیر",
                ProvinceId = 3
            },
            new()
            {
                Id = 123,
                Name = "ابریشم",
                Slug = "ابریشم",
                ProvinceId = 4
            },
            new()
            {
                Id = 124,
                Name = "ابوزیدآباد",
                Slug = "ابوزیدآباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 125,
                Name = "اردستان",
                Slug = "اردستان",
                ProvinceId = 4
            },
            new()
            {
                Id = 126,
                Name = "اژیه",
                Slug = "اژیه",
                ProvinceId = 4
            },
            new()
            {
                Id = 127,
                Name = "اصفهان",
                Slug = "اصفهان",
                ProvinceId = 4
            },
            new()
            {
                Id = 128,
                Name = "افوس",
                Slug = "افوس",
                ProvinceId = 4
            },
            new()
            {
                Id = 129,
                Name = "انارک",
                Slug = "انارک",
                ProvinceId = 4
            },
            new()
            {
                Id = 130,
                Name = "ایمانشهر",
                Slug = "ایمانشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 131,
                Name = "آران وبیدگل",
                Slug = "آران-وبیدگل",
                ProvinceId = 4
            },
            new()
            {
                Id = 132,
                Name = "بادرود",
                Slug = "بادرود",
                ProvinceId = 4
            },
            new()
            {
                Id = 133,
                Name = "باغ بهادران",
                Slug = "باغ-بهادران",
                ProvinceId = 4
            },
            new()
            {
                Id = 134,
                Name = "بافران",
                Slug = "بافران",
                ProvinceId = 4
            },
            new()
            {
                Id = 135,
                Name = "برزک",
                Slug = "برزک",
                ProvinceId = 4
            },
            new()
            {
                Id = 136,
                Name = "برف انبار",
                Slug = "برف-انبار",
                ProvinceId = 4
            },
            new()
            {
                Id = 137,
                Name = "بهاران شهر",
                Slug = "بهاران-شهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 138,
                Name = "بهارستان",
                Slug = "بهارستان",
                ProvinceId = 4
            },
            new()
            {
                Id = 139,
                Name = "بوئین و میاندشت",
                Slug = "بوئین-میاندشت",
                ProvinceId = 4
            },
            new()
            {
                Id = 140,
                Name = "پیربکران",
                Slug = "پیربکران",
                ProvinceId = 4
            },
            new()
            {
                Id = 141,
                Name = "تودشک",
                Slug = "تودشک",
                ProvinceId = 4
            },
            new()
            {
                Id = 142,
                Name = "تیران",
                Slug = "تیران",
                ProvinceId = 4
            },
            new()
            {
                Id = 143,
                Name = "جندق",
                Slug = "جندق",
                ProvinceId = 4
            },
            new()
            {
                Id = 144,
                Name = "جوزدان",
                Slug = "جوزدان",
                ProvinceId = 4
            },
            new()
            {
                Id = 145,
                Name = "جوشقان و کامو",
                Slug = "جوشقان-کامو",
                ProvinceId = 4
            },
            new()
            {
                Id = 146,
                Name = "چادگان",
                Slug = "چادگان",
                ProvinceId = 4
            },
            new()
            {
                Id = 147,
                Name = "چرمهین",
                Slug = "چرمهین",
                ProvinceId = 4
            },
            new()
            {
                Id = 148,
                Name = "چمگردان",
                Slug = "چمگردان",
                ProvinceId = 4
            },
            new()
            {
                Id = 149,
                Name = "حبیب آباد",
                Slug = "حبیب-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 150,
                Name = "حسن آباد",
                Slug = "اصفهان-حسن-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 151,
                Name = "حنا",
                Slug = "حنا",
                ProvinceId = 4
            },
            new()
            {
                Id = 152,
                Name = "خالدآباد",
                Slug = "خالدآباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 153,
                Name = "خمینی شهر",
                Slug = "خمینی-شهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 154,
                Name = "خوانسار",
                Slug = "خوانسار",
                ProvinceId = 4
            },
            new()
            {
                Id = 155,
                Name = "خور",
                Slug = "اصفهان-خور",
                ProvinceId = 4
            },
            new()
            {
                Id = 157,
                Name = "خورزوق",
                Slug = "خورزوق",
                ProvinceId = 4
            },
            new()
            {
                Id = 158,
                Name = "داران",
                Slug = "داران",
                ProvinceId = 4
            },
            new()
            {
                Id = 159,
                Name = "دامنه",
                Slug = "دامنه",
                ProvinceId = 4
            },
            new()
            {
                Id = 160,
                Name = "درچه",
                Slug = "درچه",
                ProvinceId = 4
            },
            new()
            {
                Id = 161,
                Name = "دستگرد",
                Slug = "دستگرد",
                ProvinceId = 4
            },
            new()
            {
                Id = 162,
                Name = "دهاقان",
                Slug = "دهاقان",
                ProvinceId = 4
            },
            new()
            {
                Id = 163,
                Name = "دهق",
                Slug = "دهق",
                ProvinceId = 4
            },
            new()
            {
                Id = 164,
                Name = "دولت آباد",
                Slug = "اصفهان-دولت-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 165,
                Name = "دیزیچه",
                Slug = "دیزیچه",
                ProvinceId = 4
            },
            new()
            {
                Id = 166,
                Name = "رزوه",
                Slug = "رزوه",
                ProvinceId = 4
            },
            new()
            {
                Id = 167,
                Name = "رضوانشهر",
                Slug = "اصفهان-رضوانشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 168,
                Name = "زاینده رود",
                Slug = "زاینده-رود",
                ProvinceId = 4
            },
            new()
            {
                Id = 169,
                Name = "زرین شهر",
                Slug = "زرین-شهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 170,
                Name = "زواره",
                Slug = "زواره",
                ProvinceId = 4
            },
            new()
            {
                Id = 171,
                Name = "زیباشهر",
                Slug = "زیباشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 172,
                Name = "سده لنجان",
                Slug = "سده-لنجان",
                ProvinceId = 4
            },
            new()
            {
                Id = 173,
                Name = "سفیدشهر",
                Slug = "سفیدشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 174,
                Name = "سگزی",
                Slug = "سگزی",
                ProvinceId = 4
            },
            new()
            {
                Id = 175,
                Name = "سمیرم",
                Slug = "سمیرم",
                ProvinceId = 4
            },
            new()
            {
                Id = 176,
                Name = "شاهین شهر",
                Slug = "شاهین-شهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 177,
                Name = "شهرضا",
                Slug = "شهرضا",
                ProvinceId = 4
            },
            new()
            {
                Id = 178,
                Name = "طالخونچه",
                Slug = "طالخونچه",
                ProvinceId = 4
            },
            new()
            {
                Id = 179,
                Name = "عسگران",
                Slug = "عسگران",
                ProvinceId = 4
            },
            new()
            {
                Id = 180,
                Name = "علویجه",
                Slug = "علویجه",
                ProvinceId = 4
            },
            new()
            {
                Id = 181,
                Name = "فرخی",
                Slug = "فرخی",
                ProvinceId = 4
            },
            new()
            {
                Id = 182,
                Name = "فریدونشهر",
                Slug = "فریدونشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 183,
                Name = "فلاورجان",
                Slug = "فلاورجان",
                ProvinceId = 4
            },
            new()
            {
                Id = 184,
                Name = "فولادشهر",
                Slug = "فولادشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 185,
                Name = "قمصر",
                Slug = "قمصر",
                ProvinceId = 4
            },
            new()
            {
                Id = 186,
                Name = "قهجاورستان",
                Slug = "قهجاورستان",
                ProvinceId = 4
            },
            new()
            {
                Id = 187,
                Name = "قهدریجان",
                Slug = "قهدریجان",
                ProvinceId = 4
            },
            new()
            {
                Id = 188,
                Name = "کاشان",
                Slug = "کاشان",
                ProvinceId = 4
            },
            new()
            {
                Id = 189,
                Name = "کرکوند",
                Slug = "کرکوند",
                ProvinceId = 4
            },
            new()
            {
                Id = 190,
                Name = "کلیشاد و سودرجان",
                Slug = "کلیشاد-سودرجان",
                ProvinceId = 4
            },
            new()
            {
                Id = 191,
                Name = "کمشچه",
                Slug = "کمشچه",
                ProvinceId = 4
            },
            new()
            {
                Id = 192,
                Name = "کمه",
                Slug = "کمه",
                ProvinceId = 4
            },
            new()
            {
                Id = 193,
                Name = "کهریزسنگ",
                Slug = "کهریزسنگ",
                ProvinceId = 4
            },
            new()
            {
                Id = 194,
                Name = "کوشک",
                Slug = "کوشک",
                ProvinceId = 4
            },
            new()
            {
                Id = 195,
                Name = "کوهپایه",
                Slug = "کوهپایه",
                ProvinceId = 4
            },
            new()
            {
                Id = 196,
                Name = "گرگاب",
                Slug = "گرگاب",
                ProvinceId = 4
            },
            new()
            {
                Id = 197,
                Name = "گزبرخوار",
                Slug = "گزبرخوار",
                ProvinceId = 4
            },
            new()
            {
                Id = 198,
                Name = "گلپایگان",
                Slug = "گلپایگان",
                ProvinceId = 4
            },
            new()
            {
                Id = 199,
                Name = "گلدشت",
                Slug = "گلدشت",
                ProvinceId = 4
            },
            new()
            {
                Id = 200,
                Name = "گلشهر",
                Slug = "گلشهر",
                ProvinceId = 4
            },
            new()
            {
                Id = 201,
                Name = "گوگد",
                Slug = "گوگد",
                ProvinceId = 4
            },
            new()
            {
                Id = 202,
                Name = "لای بید",
                Slug = "لای-بید",
                ProvinceId = 4
            },
            new()
            {
                Id = 203,
                Name = "مبارکه",
                Slug = "مبارکه",
                ProvinceId = 4
            },
            new()
            {
                Id = 204,
                Name = "مجلسی",
                Slug = "مجلسی",
                ProvinceId = 4
            },
            new()
            {
                Id = 205,
                Name = "محمدآباد",
                Slug = "اصفهان-محمدآباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 206,
                Name = "مشکات",
                Slug = "مشکات",
                ProvinceId = 4
            },
            new()
            {
                Id = 207,
                Name = "منظریه",
                Slug = "منظریه",
                ProvinceId = 4
            },
            new()
            {
                Id = 208,
                Name = "مهاباد",
                Slug = "اصفهان-مهاباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 209,
                Name = "میمه",
                Slug = "اصفهان-میمه",
                ProvinceId = 4
            },
            new()
            {
                Id = 210,
                Name = "نائین",
                Slug = "نائین",
                ProvinceId = 4
            },
            new()
            {
                Id = 211,
                Name = "نجف آباد",
                Slug = "نجف-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 212,
                Name = "نصرآباد",
                Slug = "اصفهان-نصرآباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 213,
                Name = "نطنز",
                Slug = "نطنز",
                ProvinceId = 4
            },
            new()
            {
                Id = 214,
                Name = "نوش آباد",
                Slug = "نوش-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 215,
                Name = "نیاسر",
                Slug = "نیاسر",
                ProvinceId = 4
            },
            new()
            {
                Id = 216,
                Name = "نیک آباد",
                Slug = "نیک-آباد",
                ProvinceId = 4
            },
            new()
            {
                Id = 217,
                Name = "هرند",
                Slug = "هرند",
                ProvinceId = 4
            },
            new()
            {
                Id = 218,
                Name = "ورزنه",
                Slug = "ورزنه",
                ProvinceId = 4
            },
            new()
            {
                Id = 219,
                Name = "ورنامخواست",
                Slug = "ورنامخواست",
                ProvinceId = 4
            },
            new()
            {
                Id = 220,
                Name = "وزوان",
                Slug = "وزوان",
                ProvinceId = 4
            },
            new()
            {
                Id = 221,
                Name = "ونک",
                Slug = "ونک",
                ProvinceId = 4
            },
            new()
            {
                Id = 222,
                Name = "اسارا",
                Slug = "اسارا",
                ProvinceId = 5
            },
            new()
            {
                Id = 223,
                Name = "اشتهارد",
                Slug = "اشتهارد",
                ProvinceId = 5
            },
            new()
            {
                Id = 224,
                Name = "تنکمان",
                Slug = "تنکمان",
                ProvinceId = 5
            },
            new()
            {
                Id = 225,
                Name = "چهارباغ",
                Slug = "چهارباغ",
                ProvinceId = 5
            },
            new()
            {
                Id = 226,
                Name = "سعید آباد",
                Slug = "سعید-آباد",
                ProvinceId = 5
            },
            new()
            {
                Id = 227,
                Name = "شهر جدید هشتگرد",
                Slug = "شهر-جدید-هشتگرد",
                ProvinceId = 5
            },
            new()
            {
                Id = 228,
                Name = "طالقان",
                Slug = "طالقان",
                ProvinceId = 5
            },
            new()
            {
                Id = 229,
                Name = "کرج",
                Slug = "کرج",
                ProvinceId = 5
            },
            new()
            {
                Id = 230,
                Name = "کمال شهر",
                Slug = "کمال-شهر",
                ProvinceId = 5
            },
            new()
            {
                Id = 231,
                Name = "کوهسار",
                Slug = "کوهسار",
                ProvinceId = 5
            },
            new()
            {
                Id = 232,
                Name = "گرمدره",
                Slug = "گرمدره",
                ProvinceId = 5
            },
            new()
            {
                Id = 233,
                Name = "ماهدشت",
                Slug = "ماهدشت",
                ProvinceId = 5
            },
            new()
            {
                Id = 234,
                Name = "محمدشهر",
                Slug = "البرز-محمدشهر",
                ProvinceId = 5
            },
            new()
            {
                Id = 235,
                Name = "مشکین دشت",
                Slug = "مشکین-دشت",
                ProvinceId = 5
            },
            new()
            {
                Id = 236,
                Name = "نظرآباد",
                Slug = "نظرآباد",
                ProvinceId = 5
            },
            new()
            {
                Id = 237,
                Name = "هشتگرد",
                Slug = "هشتگرد",
                ProvinceId = 5
            },
            new()
            {
                Id = 238,
                Name = "ارکواز",
                Slug = "ارکواز",
                ProvinceId = 6
            },
            new()
            {
                Id = 239,
                Name = "ایلام",
                Slug = "ایلام",
                ProvinceId = 6
            },
            new()
            {
                Id = 240,
                Name = "ایوان",
                Slug = "ایوان",
                ProvinceId = 6
            },
            new()
            {
                Id = 241,
                Name = "آبدانان",
                Slug = "آبدانان",
                ProvinceId = 6
            },
            new()
            {
                Id = 242,
                Name = "آسمان آباد",
                Slug = "آسمان-آباد",
                ProvinceId = 6
            },
            new()
            {
                Id = 243,
                Name = "بدره",
                Slug = "بدره",
                ProvinceId = 6
            },
            new()
            {
                Id = 244,
                Name = "پهله",
                Slug = "پهله",
                ProvinceId = 6
            },
            new()
            {
                Id = 245,
                Name = "توحید",
                Slug = "توحید",
                ProvinceId = 6
            },
            new()
            {
                Id = 246,
                Name = "چوار",
                Slug = "چوار",
                ProvinceId = 6
            },
            new()
            {
                Id = 247,
                Name = "دره شهر",
                Slug = "دره-شهر",
                ProvinceId = 6
            },
            new()
            {
                Id = 248,
                Name = "دلگشا",
                Slug = "دلگشا",
                ProvinceId = 6
            },
            new()
            {
                Id = 249,
                Name = "دهلران",
                Slug = "دهلران",
                ProvinceId = 6
            },
            new()
            {
                Id = 250,
                Name = "زرنه",
                Slug = "زرنه",
                ProvinceId = 6
            },
            new()
            {
                Id = 251,
                Name = "سراب باغ",
                Slug = "سراب-باغ",
                ProvinceId = 6
            },
            new()
            {
                Id = 252,
                Name = "سرابله",
                Slug = "سرابله",
                ProvinceId = 6
            },
            new()
            {
                Id = 253,
                Name = "صالح آباد",
                Slug = "ایلام-صالح-آباد",
                ProvinceId = 6
            },
            new()
            {
                Id = 254,
                Name = "لومار",
                Slug = "لومار",
                ProvinceId = 6
            },
            new()
            {
                Id = 255,
                Name = "مهران",
                Slug = "مهران",
                ProvinceId = 6
            },
            new()
            {
                Id = 256,
                Name = "مورموری",
                Slug = "مورموری",
                ProvinceId = 6
            },
            new()
            {
                Id = 257,
                Name = "موسیان",
                Slug = "موسیان",
                ProvinceId = 6
            },
            new()
            {
                Id = 258,
                Name = "میمه",
                Slug = "ایلام-میمه",
                ProvinceId = 6
            },
            new()
            {
                Id = 259,
                Name = "امام حسن",
                Slug = "امام-حسن",
                ProvinceId = 7
            },
            new()
            {
                Id = 260,
                Name = "انارستان",
                Slug = "انارستان",
                ProvinceId = 7
            },
            new()
            {
                Id = 261,
                Name = "اهرم",
                Slug = "اهرم",
                ProvinceId = 7
            },
            new()
            {
                Id = 262,
                Name = "آب پخش",
                Slug = "آب-پخش",
                ProvinceId = 7
            },
            new()
            {
                Id = 263,
                Name = "آبدان",
                Slug = "آبدان",
                ProvinceId = 7
            },
            new()
            {
                Id = 264,
                Name = "برازجان",
                Slug = "برازجان",
                ProvinceId = 7
            },
            new()
            {
                Id = 265,
                Name = "بردخون",
                Slug = "بردخون",
                ProvinceId = 7
            },
            new()
            {
                Id = 266,
                Name = "بندردیر",
                Slug = "بندردیر",
                ProvinceId = 7
            },
            new()
            {
                Id = 267,
                Name = "بندردیلم",
                Slug = "بندردیلم",
                ProvinceId = 7
            },
            new()
            {
                Id = 268,
                Name = "بندرریگ",
                Slug = "بندرریگ",
                ProvinceId = 7
            },
            new()
            {
                Id = 269,
                Name = "بندرکنگان",
                Slug = "بندرکنگان",
                ProvinceId = 7
            },
            new()
            {
                Id = 270,
                Name = "بندرگناوه",
                Slug = "بندرگناوه",
                ProvinceId = 7
            },
            new()
            {
                Id = 271,
                Name = "بنک",
                Slug = "بنک",
                ProvinceId = 7
            },
            new()
            {
                Id = 272,
                Name = "بوشهر",
                Slug = "بوشهر",
                ProvinceId = 7
            },
            new()
            {
                Id = 273,
                Name = "تنگ ارم",
                Slug = "تنگ-ارم",
                ProvinceId = 7
            },
            new()
            {
                Id = 274,
                Name = "جم",
                Slug = "جم",
                ProvinceId = 7
            },
            new()
            {
                Id = 275,
                Name = "چغادک",
                Slug = "چغادک",
                ProvinceId = 7
            },
            new()
            {
                Id = 276,
                Name = "خارک",
                Slug = "خارک",
                ProvinceId = 7
            },
            new()
            {
                Id = 277,
                Name = "خورموج",
                Slug = "خورموج",
                ProvinceId = 7
            },
            new()
            {
                Id = 278,
                Name = "دالکی",
                Slug = "دالکی",
                ProvinceId = 7
            },
            new()
            {
                Id = 279,
                Name = "دلوار",
                Slug = "دلوار",
                ProvinceId = 7
            },
            new()
            {
                Id = 280,
                Name = "ریز",
                Slug = "ریز",
                ProvinceId = 7
            },
            new()
            {
                Id = 281,
                Name = "سعدآباد",
                Slug = "سعدآباد",
                ProvinceId = 7
            },
            new()
            {
                Id = 282,
                Name = "سیراف",
                Slug = "سیراف",
                ProvinceId = 7
            },
            new()
            {
                Id = 283,
                Name = "شبانکاره",
                Slug = "شبانکاره",
                ProvinceId = 7
            },
            new()
            {
                Id = 284,
                Name = "شنبه",
                Slug = "شنبه",
                ProvinceId = 7
            },
            new()
            {
                Id = 285,
                Name = "عسلویه",
                Slug = "عسلویه",
                ProvinceId = 7
            },
            new()
            {
                Id = 286,
                Name = "کاکی",
                Slug = "کاکی",
                ProvinceId = 7
            },
            new()
            {
                Id = 287,
                Name = "کلمه",
                Slug = "کلمه",
                ProvinceId = 7
            },
            new()
            {
                Id = 288,
                Name = "نخل تقی",
                Slug = "نخل-تقی",
                ProvinceId = 7
            },
            new()
            {
                Id = 289,
                Name = "وحدتیه",
                Slug = "وحدتیه",
                ProvinceId = 7
            },
            new()
            {
                Id = 290,
                Name = "ارجمند",
                Slug = "ارجمند",
                ProvinceId = 8
            },
            new()
            {
                Id = 291,
                Name = "اسلامشهر",
                Slug = "اسلامشهر",
                ProvinceId = 8
            },
            new()
            {
                Id = 292,
                Name = "اندیشه",
                Slug = "اندیشه",
                ProvinceId = 8
            },
            new()
            {
                Id = 293,
                Name = "آبسرد",
                Slug = "آبسرد",
                ProvinceId = 8
            },
            new()
            {
                Id = 294,
                Name = "آبعلی",
                Slug = "آبعلی",
                ProvinceId = 8
            },
            new()
            {
                Id = 295,
                Name = "باغستان",
                Slug = "باغستان",
                ProvinceId = 8
            },
            new()
            {
                Id = 296,
                Name = "باقرشهر",
                Slug = "باقرشهر",
                ProvinceId = 8
            },
            new()
            {
                Id = 297,
                Name = "بومهن",
                Slug = "بومهن",
                ProvinceId = 8
            },
            new()
            {
                Id = 298,
                Name = "پاکدشت",
                Slug = "پاکدشت",
                ProvinceId = 8
            },
            new()
            {
                Id = 299,
                Name = "پردیس",
                Slug = "پردیس",
                ProvinceId = 8
            },
            new()
            {
                Id = 300,
                Name = "پیشوا",
                Slug = "پیشوا",
                ProvinceId = 8
            },
            new()
            {
                Id = 301,
                Name = "تهران",
                Slug = "تهران",
                ProvinceId = 8
            },
            new()
            {
                Id = 302,
                Name = "جوادآباد",
                Slug = "جوادآباد",
                ProvinceId = 8
            },
            new()
            {
                Id = 303,
                Name = "چهاردانگه",
                Slug = "چهاردانگه",
                ProvinceId = 8
            },
            new()
            {
                Id = 304,
                Name = "حسن آباد",
                Slug = "تهران-حسن-آباد",
                ProvinceId = 8
            },
            new()
            {
                Id = 305,
                Name = "دماوند",
                Slug = "دماوند",
                ProvinceId = 8
            },
            new()
            {
                Id = 306,
                Name = "دیزین",
                Slug = "دیزین",
                ProvinceId = 8
            },
            new()
            {
                Id = 307,
                Name = "شهر ری",
                Slug = "شهر-ری",
                ProvinceId = 8
            },
            new()
            {
                Id = 308,
                Name = "رباط کریم",
                Slug = "رباط-کریم",
                ProvinceId = 8
            },
            new()
            {
                Id = 309,
                Name = "رودهن",
                Slug = "رودهن",
                ProvinceId = 8
            },
            new()
            {
                Id = 310,
                Name = "شاهدشهر",
                Slug = "شاهدشهر",
                ProvinceId = 8
            },
            new()
            {
                Id = 311,
                Name = "شریف آباد",
                Slug = "شریف-آباد",
                ProvinceId = 8
            },
            new()
            {
                Id = 312,
                Name = "شمشک",
                Slug = "شمشک",
                ProvinceId = 8
            },
            new()
            {
                Id = 313,
                Name = "شهریار",
                Slug = "شهریار",
                ProvinceId = 8
            },
            new()
            {
                Id = 314,
                Name = "صالح آباد",
                Slug = "تهران-صالح-آباد",
                ProvinceId = 8
            },
            new()
            {
                Id = 315,
                Name = "صباشهر",
                Slug = "صباشهر",
                ProvinceId = 8
            },
            new()
            {
                Id = 316,
                Name = "صفادشت",
                Slug = "صفادشت",
                ProvinceId = 8
            },
            new()
            {
                Id = 317,
                Name = "فردوسیه",
                Slug = "فردوسیه",
                ProvinceId = 8
            },
            new()
            {
                Id = 318,
                Name = "فشم",
                Slug = "فشم",
                ProvinceId = 8
            },
            new()
            {
                Id = 319,
                Name = "فیروزکوه",
                Slug = "فیروزکوه",
                ProvinceId = 8
            },
            new()
            {
                Id = 320,
                Name = "قدس",
                Slug = "قدس",
                ProvinceId = 8
            },
            new()
            {
                Id = 321,
                Name = "قرچک",
                Slug = "قرچک",
                ProvinceId = 8
            },
            new()
            {
                Id = 322,
                Name = "کهریزک",
                Slug = "کهریزک",
                ProvinceId = 8
            },
            new()
            {
                Id = 323,
                Name = "کیلان",
                Slug = "کیلان",
                ProvinceId = 8
            },
            new()
            {
                Id = 324,
                Name = "گلستان",
                Slug = "شهر-گلستان",
                ProvinceId = 8
            },
            new()
            {
                Id = 325,
                Name = "لواسان",
                Slug = "لواسان",
                ProvinceId = 8
            },
            new()
            {
                Id = 326,
                Name = "ملارد",
                Slug = "ملارد",
                ProvinceId = 8
            },
            new()
            {
                Id = 327,
                Name = "میگون",
                Slug = "میگون",
                ProvinceId = 8
            },
            new()
            {
                Id = 328,
                Name = "نسیم شهر",
                Slug = "نسیم-شهر",
                ProvinceId = 8
            },
            new()
            {
                Id = 329,
                Name = "نصیرآباد",
                Slug = "نصیرآباد",
                ProvinceId = 8
            },
            new()
            {
                Id = 330,
                Name = "وحیدیه",
                Slug = "وحیدیه",
                ProvinceId = 8
            },
            new()
            {
                Id = 331,
                Name = "ورامین",
                Slug = "ورامین",
                ProvinceId = 8
            },
            new()
            {
                Id = 332,
                Name = "اردل",
                Slug = "اردل",
                ProvinceId = 9
            },
            new()
            {
                Id = 333,
                Name = "آلونی",
                Slug = "آلونی",
                ProvinceId = 9
            },
            new()
            {
                Id = 334,
                Name = "باباحیدر",
                Slug = "باباحیدر",
                ProvinceId = 9
            },
            new()
            {
                Id = 335,
                Name = "بروجن",
                Slug = "بروجن",
                ProvinceId = 9
            },
            new()
            {
                Id = 336,
                Name = "بلداجی",
                Slug = "بلداجی",
                ProvinceId = 9
            },
            new()
            {
                Id = 337,
                Name = "بن",
                Slug = "بن",
                ProvinceId = 9
            },
            new()
            {
                Id = 338,
                Name = "جونقان",
                Slug = "جونقان",
                ProvinceId = 9
            },
            new()
            {
                Id = 339,
                Name = "چلگرد",
                Slug = "چلگرد",
                ProvinceId = 9
            },
            new()
            {
                Id = 340,
                Name = "سامان",
                Slug = "سامان",
                ProvinceId = 9
            },
            new()
            {
                Id = 341,
                Name = "سفیددشت",
                Slug = "سفیددشت",
                ProvinceId = 9
            },
            new()
            {
                Id = 342,
                Name = "سودجان",
                Slug = "سودجان",
                ProvinceId = 9
            },
            new()
            {
                Id = 343,
                Name = "سورشجان",
                Slug = "سورشجان",
                ProvinceId = 9
            },
            new()
            {
                Id = 344,
                Name = "شلمزار",
                Slug = "شلمزار",
                ProvinceId = 9
            },
            new()
            {
                Id = 345,
                Name = "شهرکرد",
                Slug = "شهرکرد",
                ProvinceId = 9
            },
            new()
            {
                Id = 346,
                Name = "طاقانک",
                Slug = "طاقانک",
                ProvinceId = 9
            },
            new()
            {
                Id = 347,
                Name = "فارسان",
                Slug = "فارسان",
                ProvinceId = 9
            },
            new()
            {
                Id = 348,
                Name = "فرادنبه",
                Slug = "فرادبنه",
                ProvinceId = 9
            },
            new()
            {
                Id = 349,
                Name = "فرخ شهر",
                Slug = "فرخ-شهر",
                ProvinceId = 9
            },
            new()
            {
                Id = 350,
                Name = "کیان",
                Slug = "کیان",
                ProvinceId = 9
            },
            new()
            {
                Id = 351,
                Name = "گندمان",
                Slug = "گندمان",
                ProvinceId = 9
            },
            new()
            {
                Id = 352,
                Name = "گهرو",
                Slug = "گهرو",
                ProvinceId = 9
            },
            new()
            {
                Id = 353,
                Name = "لردگان",
                Slug = "لردگان",
                ProvinceId = 9
            },
            new()
            {
                Id = 354,
                Name = "مال خلیفه",
                Slug = "مال-خلیفه",
                ProvinceId = 9
            },
            new()
            {
                Id = 355,
                Name = "ناغان",
                Slug = "ناغان",
                ProvinceId = 9
            },
            new()
            {
                Id = 356,
                Name = "نافچ",
                Slug = "نافچ",
                ProvinceId = 9
            },
            new()
            {
                Id = 357,
                Name = "نقنه",
                Slug = "نقنه",
                ProvinceId = 9
            },
            new()
            {
                Id = 358,
                Name = "هفشجان",
                Slug = "هفشجان",
                ProvinceId = 9
            },
            new()
            {
                Id = 359,
                Name = "ارسک",
                Slug = "ارسک",
                ProvinceId = 10
            },
            new()
            {
                Id = 360,
                Name = "اسدیه",
                Slug = "اسدیه",
                ProvinceId = 10
            },
            new()
            {
                Id = 361,
                Name = "اسفدن",
                Slug = "اسفدن",
                ProvinceId = 10
            },
            new()
            {
                Id = 362,
                Name = "اسلامیه",
                Slug = "اسلامیه",
                ProvinceId = 10
            },
            new()
            {
                Id = 363,
                Name = "آرین شهر",
                Slug = "آرین-شهر",
                ProvinceId = 10
            },
            new()
            {
                Id = 364,
                Name = "آیسک",
                Slug = "آیسک",
                ProvinceId = 10
            },
            new()
            {
                Id = 365,
                Name = "بشرویه",
                Slug = "بشرویه",
                ProvinceId = 10
            },
            new()
            {
                Id = 366,
                Name = "بیرجند",
                Slug = "بیرجند",
                ProvinceId = 10
            },
            new()
            {
                Id = 367,
                Name = "حاجی آباد",
                Slug = "خراسان-جنوبی-حاجی-آباد",
                ProvinceId = 10
            },
            new()
            {
                Id = 368,
                Name = "خضری دشت بیاض",
                Slug = "خضری-دشت-بیاض",
                ProvinceId = 10
            },
            new()
            {
                Id = 369,
                Name = "خوسف",
                Slug = "خوسف",
                ProvinceId = 10
            },
            new()
            {
                Id = 370,
                Name = "زهان",
                Slug = "زهان",
                ProvinceId = 10
            },
            new()
            {
                Id = 371,
                Name = "سرایان",
                Slug = "سرایان",
                ProvinceId = 10
            },
            new()
            {
                Id = 372,
                Name = "سربیشه",
                Slug = "سربیشه",
                ProvinceId = 10
            },
            new()
            {
                Id = 373,
                Name = "سه قلعه",
                Slug = "سه-قلعه",
                ProvinceId = 10
            },
            new()
            {
                Id = 374,
                Name = "شوسف",
                Slug = "شوسف",
                ProvinceId = 10
            },
            new()
            {
                Id = 375,
                Name = "طبس ",
                Slug = "خراسان-جنوبی-طبس-",
                ProvinceId = 10
            },
            new()
            {
                Id = 376,
                Name = "فردوس",
                Slug = "فردوس",
                ProvinceId = 10
            },
            new()
            {
                Id = 377,
                Name = "قاین",
                Slug = "قاین",
                ProvinceId = 10
            },
            new()
            {
                Id = 378,
                Name = "قهستان",
                Slug = "قهستان",
                ProvinceId = 10
            },
            new()
            {
                Id = 379,
                Name = "محمدشهر",
                Slug = "خراسان-جنوبی-محمدشهر",
                ProvinceId = 10
            },
            new()
            {
                Id = 380,
                Name = "مود",
                Slug = "مود",
                ProvinceId = 10
            },
            new()
            {
                Id = 381,
                Name = "نهبندان",
                Slug = "نهبندان",
                ProvinceId = 10
            },
            new()
            {
                Id = 382,
                Name = "نیمبلوک",
                Slug = "نیمبلوک",
                ProvinceId = 10
            },
            new()
            {
                Id = 383,
                Name = "احمدآباد صولت",
                Slug = "احمدآباد-صولت",
                ProvinceId = 11
            },
            new()
            {
                Id = 384,
                Name = "انابد",
                Slug = "انابد",
                ProvinceId = 11
            },
            new()
            {
                Id = 385,
                Name = "باجگیران",
                Slug = "باجگیران",
                ProvinceId = 11
            },
            new()
            {
                Id = 386,
                Name = "باخرز",
                Slug = "باخرز",
                ProvinceId = 11
            },
            new()
            {
                Id = 387,
                Name = "بار",
                Slug = "بار",
                ProvinceId = 11
            },
            new()
            {
                Id = 388,
                Name = "بایگ",
                Slug = "بایگ",
                ProvinceId = 11
            },
            new()
            {
                Id = 389,
                Name = "بجستان",
                Slug = "بجستان",
                ProvinceId = 11
            },
            new()
            {
                Id = 390,
                Name = "بردسکن",
                Slug = "بردسکن",
                ProvinceId = 11
            },
            new()
            {
                Id = 391,
                Name = "بیدخت",
                Slug = "بیدخت",
                ProvinceId = 11
            },
            new()
            {
                Id = 392,
                Name = "تایباد",
                Slug = "تایباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 393,
                Name = "تربت جام",
                Slug = "تربت-جام",
                ProvinceId = 11
            },
            new()
            {
                Id = 394,
                Name = "تربت حیدریه",
                Slug = "تربت-حیدریه",
                ProvinceId = 11
            },
            new()
            {
                Id = 395,
                Name = "جغتای",
                Slug = "جغتای",
                ProvinceId = 11
            },
            new()
            {
                Id = 396,
                Name = "جنگل",
                Slug = "جنگل",
                ProvinceId = 11
            },
            new()
            {
                Id = 397,
                Name = "چاپشلو",
                Slug = "چاپشلو",
                ProvinceId = 11
            },
            new()
            {
                Id = 398,
                Name = "چکنه",
                Slug = "چکنه",
                ProvinceId = 11
            },
            new()
            {
                Id = 399,
                Name = "چناران",
                Slug = "چناران",
                ProvinceId = 11
            },
            new()
            {
                Id = 400,
                Name = "خرو",
                Slug = "خرو",
                ProvinceId = 11
            },
            new()
            {
                Id = 401,
                Name = "خلیل آباد",
                Slug = "خلیل-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 402,
                Name = "خواف",
                Slug = "خواف",
                ProvinceId = 11
            },
            new()
            {
                Id = 403,
                Name = "داورزن",
                Slug = "داورزن",
                ProvinceId = 11
            },
            new()
            {
                Id = 404,
                Name = "درگز",
                Slug = "درگز",
                ProvinceId = 11
            },
            new()
            {
                Id = 405,
                Name = "در رود",
                Slug = "در-رود",
                ProvinceId = 11
            },
            new()
            {
                Id = 406,
                Name = "دولت آباد",
                Slug = "خراسان-رضوی-دولت-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 407,
                Name = "رباط سنگ",
                Slug = "رباط-سنگ",
                ProvinceId = 11
            },
            new()
            {
                Id = 408,
                Name = "رشتخوار",
                Slug = "رشتخوار",
                ProvinceId = 11
            },
            new()
            {
                Id = 409,
                Name = "رضویه",
                Slug = "رضویه",
                ProvinceId = 11
            },
            new()
            {
                Id = 410,
                Name = "روداب",
                Slug = "روداب",
                ProvinceId = 11
            },
            new()
            {
                Id = 411,
                Name = "ریوش",
                Slug = "ریوش",
                ProvinceId = 11
            },
            new()
            {
                Id = 412,
                Name = "سبزوار",
                Slug = "سبزوار",
                ProvinceId = 11
            },
            new()
            {
                Id = 413,
                Name = "سرخس",
                Slug = "سرخس",
                ProvinceId = 11
            },
            new()
            {
                Id = 414,
                Name = "سفیدسنگ",
                Slug = "سفیدسنگ",
                ProvinceId = 11
            },
            new()
            {
                Id = 415,
                Name = "سلامی",
                Slug = "سلامی",
                ProvinceId = 11
            },
            new()
            {
                Id = 416,
                Name = "سلطان آباد",
                Slug = "سلطان-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 417,
                Name = "سنگان",
                Slug = "سنگان",
                ProvinceId = 11
            },
            new()
            {
                Id = 418,
                Name = "شادمهر",
                Slug = "شادمهر",
                ProvinceId = 11
            },
            new()
            {
                Id = 419,
                Name = "شاندیز",
                Slug = "شاندیز",
                ProvinceId = 11
            },
            new()
            {
                Id = 420,
                Name = "ششتمد",
                Slug = "ششتمد",
                ProvinceId = 11
            },
            new()
            {
                Id = 421,
                Name = "شهرآباد",
                Slug = "شهرآباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 422,
                Name = "شهرزو",
                Slug = "شهرزو",
                ProvinceId = 11
            },
            new()
            {
                Id = 423,
                Name = "صالح آباد",
                Slug = "خراسان-رضوی-صالح-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 424,
                Name = "طرقبه",
                Slug = "طرقبه",
                ProvinceId = 11
            },
            new()
            {
                Id = 425,
                Name = "عشق آباد",
                Slug = "خراسان-رضوی-عشق-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 426,
                Name = "فرهادگرد",
                Slug = "فرهادگرد",
                ProvinceId = 11
            },
            new()
            {
                Id = 427,
                Name = "فریمان",
                Slug = "فریمان",
                ProvinceId = 11
            },
            new()
            {
                Id = 428,
                Name = "فیروزه",
                Slug = "فیروزه",
                ProvinceId = 11
            },
            new()
            {
                Id = 429,
                Name = "فیض آباد",
                Slug = "فیض-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 430,
                Name = "قاسم آباد",
                Slug = "قاسم-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 431,
                Name = "قدمگاه",
                Slug = "قدمگاه",
                ProvinceId = 11
            },
            new()
            {
                Id = 432,
                Name = "قلندرآباد",
                Slug = "قلندرآباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 433,
                Name = "قوچان",
                Slug = "قوچان",
                ProvinceId = 11
            },
            new()
            {
                Id = 434,
                Name = "کاخک",
                Slug = "کاخک",
                ProvinceId = 11
            },
            new()
            {
                Id = 435,
                Name = "کاریز",
                Slug = "کاریز",
                ProvinceId = 11
            },
            new()
            {
                Id = 436,
                Name = "کاشمر",
                Slug = "کاشمر",
                ProvinceId = 11
            },
            new()
            {
                Id = 437,
                Name = "کدکن",
                Slug = "کدکن",
                ProvinceId = 11
            },
            new()
            {
                Id = 438,
                Name = "کلات",
                Slug = "کلات",
                ProvinceId = 11
            },
            new()
            {
                Id = 439,
                Name = "کندر",
                Slug = "کندر",
                ProvinceId = 11
            },
            new()
            {
                Id = 440,
                Name = "گلمکان",
                Slug = "گلمکان",
                ProvinceId = 11
            },
            new()
            {
                Id = 441,
                Name = "گناباد",
                Slug = "گناباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 442,
                Name = "لطف آباد",
                Slug = "لطف-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 443,
                Name = "مزدآوند",
                Slug = "مزدآوند",
                ProvinceId = 11
            },
            new()
            {
                Id = 444,
                Name = "مشهد",
                Slug = "مشهد",
                ProvinceId = 11
            },
            new()
            {
                Id = 445,
                Name = "ملک آباد",
                Slug = "ملک-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 446,
                Name = "نشتیفان",
                Slug = "نشتیفان",
                ProvinceId = 11
            },
            new()
            {
                Id = 447,
                Name = "نصرآباد",
                Slug = "خراسان-رضوی-نصرآباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 448,
                Name = "نقاب",
                Slug = "نقاب",
                ProvinceId = 11
            },
            new()
            {
                Id = 449,
                Name = "نوخندان",
                Slug = "نوخندان",
                ProvinceId = 11
            },
            new()
            {
                Id = 450,
                Name = "نیشابور",
                Slug = "نیشابور",
                ProvinceId = 11
            },
            new()
            {
                Id = 451,
                Name = "نیل شهر",
                Slug = "نیل-شهر",
                ProvinceId = 11
            },
            new()
            {
                Id = 452,
                Name = "همت آباد",
                Slug = "همت-آباد",
                ProvinceId = 11
            },
            new()
            {
                Id = 453,
                Name = "یونسی",
                Slug = "یونسی",
                ProvinceId = 11
            },
            new()
            {
                Id = 454,
                Name = "اسفراین",
                Slug = "اسفراین",
                ProvinceId = 12
            },
            new()
            {
                Id = 455,
                Name = "ایور",
                Slug = "ایور",
                ProvinceId = 12
            },
            new()
            {
                Id = 456,
                Name = "آشخانه",
                Slug = "آشخانه",
                ProvinceId = 12
            },
            new()
            {
                Id = 457,
                Name = "بجنورد",
                Slug = "بجنورد",
                ProvinceId = 12
            },
            new()
            {
                Id = 458,
                Name = "پیش قلعه",
                Slug = "پیش-قلعه",
                ProvinceId = 12
            },
            new()
            {
                Id = 459,
                Name = "تیتکانلو",
                Slug = "تیتکانلو",
                ProvinceId = 12
            },
            new()
            {
                Id = 460,
                Name = "جاجرم",
                Slug = "جاجرم",
                ProvinceId = 12
            },
            new()
            {
                Id = 461,
                Name = "حصارگرمخان",
                Slug = "حصارگرمخان",
                ProvinceId = 12
            },
            new()
            {
                Id = 462,
                Name = "درق",
                Slug = "درق",
                ProvinceId = 12
            },
            new()
            {
                Id = 463,
                Name = "راز",
                Slug = "راز",
                ProvinceId = 12
            },
            new()
            {
                Id = 464,
                Name = "سنخواست",
                Slug = "سنخواست",
                ProvinceId = 12
            },
            new()
            {
                Id = 465,
                Name = "شوقان",
                Slug = "شوقان",
                ProvinceId = 12
            },
            new()
            {
                Id = 466,
                Name = "شیروان",
                Slug = "شیروان",
                ProvinceId = 12
            },
            new()
            {
                Id = 467,
                Name = "صفی آباد",
                Slug = "خراسان-شمالی-صفی-آباد",
                ProvinceId = 12
            },
            new()
            {
                Id = 468,
                Name = "فاروج",
                Slug = "فاروج",
                ProvinceId = 12
            },
            new()
            {
                Id = 469,
                Name = "قاضی",
                Slug = "قاضی",
                ProvinceId = 12
            },
            new()
            {
                Id = 470,
                Name = "گرمه",
                Slug = "گرمه",
                ProvinceId = 12
            },
            new()
            {
                Id = 471,
                Name = "لوجلی",
                Slug = "لوجلی",
                ProvinceId = 12
            },
            new()
            {
                Id = 472,
                Name = "اروندکنار",
                Slug = "اروندکنار",
                ProvinceId = 13
            },
            new()
            {
                Id = 473,
                Name = "الوان",
                Slug = "الوان",
                ProvinceId = 13
            },
            new()
            {
                Id = 474,
                Name = "امیدیه",
                Slug = "امیدیه",
                ProvinceId = 13
            },
            new()
            {
                Id = 475,
                Name = "اندیمشک",
                Slug = "اندیمشک",
                ProvinceId = 13
            },
            new()
            {
                Id = 476,
                Name = "اهواز",
                Slug = "اهواز",
                ProvinceId = 13
            },
            new()
            {
                Id = 477,
                Name = "ایذه",
                Slug = "ایذه",
                ProvinceId = 13
            },
            new()
            {
                Id = 478,
                Name = "آبادان",
                Slug = "آبادان",
                ProvinceId = 13
            },
            new()
            {
                Id = 479,
                Name = "آغاجاری",
                Slug = "آغاجاری",
                ProvinceId = 13
            },
            new()
            {
                Id = 480,
                Name = "باغ ملک",
                Slug = "باغ-ملک",
                ProvinceId = 13
            },
            new()
            {
                Id = 481,
                Name = "بستان",
                Slug = "بستان",
                ProvinceId = 13
            },
            new()
            {
                Id = 482,
                Name = "بندرامام خمینی",
                Slug = "بندرامام-خمینی",
                ProvinceId = 13
            },
            new()
            {
                Id = 483,
                Name = "بندرماهشهر",
                Slug = "بندرماهشهر",
                ProvinceId = 13
            },
            new()
            {
                Id = 484,
                Name = "بهبهان",
                Slug = "بهبهان",
                ProvinceId = 13
            },
            new()
            {
                Id = 485,
                Name = "ترکالکی",
                Slug = "ترکالکی",
                ProvinceId = 13
            },
            new()
            {
                Id = 486,
                Name = "جایزان",
                Slug = "جایزان",
                ProvinceId = 13
            },
            new()
            {
                Id = 487,
                Name = "چمران",
                Slug = "چمران",
                ProvinceId = 13
            },
            new()
            {
                Id = 488,
                Name = "چویبده",
                Slug = "چویبده",
                ProvinceId = 13
            },
            new()
            {
                Id = 489,
                Name = "حر",
                Slug = "حر",
                ProvinceId = 13
            },
            new()
            {
                Id = 490,
                Name = "حسینیه",
                Slug = "حسینیه",
                ProvinceId = 13
            },
            new()
            {
                Id = 491,
                Name = "حمزه",
                Slug = "حمزه",
                ProvinceId = 13
            },
            new()
            {
                Id = 492,
                Name = "حمیدیه",
                Slug = "حمیدیه",
                ProvinceId = 13
            },
            new()
            {
                Id = 493,
                Name = "خرمشهر",
                Slug = "خرمشهر",
                ProvinceId = 13
            },
            new()
            {
                Id = 494,
                Name = "دارخوین",
                Slug = "دارخوین",
                ProvinceId = 13
            },
            new()
            {
                Id = 495,
                Name = "دزآب",
                Slug = "دزآب",
                ProvinceId = 13
            },
            new()
            {
                Id = 496,
                Name = "دزفول",
                Slug = "دزفول",
                ProvinceId = 13
            },
            new()
            {
                Id = 497,
                Name = "دهدز",
                Slug = "دهدز",
                ProvinceId = 13
            },
            new()
            {
                Id = 498,
                Name = "رامشیر",
                Slug = "رامشیر",
                ProvinceId = 13
            },
            new()
            {
                Id = 499,
                Name = "رامهرمز",
                Slug = "رامهرمز",
                ProvinceId = 13
            },
            new()
            {
                Id = 500,
                Name = "رفیع",
                Slug = "رفیع",
                ProvinceId = 13
            },
            new()
            {
                Id = 501,
                Name = "زهره",
                Slug = "زهره",
                ProvinceId = 13
            },
            new()
            {
                Id = 502,
                Name = "سالند",
                Slug = "سالند",
                ProvinceId = 13
            },
            new()
            {
                Id = 503,
                Name = "سردشت",
                Slug = "خوزستان-سردشت",
                ProvinceId = 13
            },
            new()
            {
                Id = 504,
                Name = "سوسنگرد",
                Slug = "سوسنگرد",
                ProvinceId = 13
            },
            new()
            {
                Id = 505,
                Name = "شادگان",
                Slug = "شادگان",
                ProvinceId = 13
            },
            new()
            {
                Id = 506,
                Name = "شاوور",
                Slug = "شاوور",
                ProvinceId = 13
            },
            new()
            {
                Id = 507,
                Name = "شرافت",
                Slug = "شرافت",
                ProvinceId = 13
            },
            new()
            {
                Id = 508,
                Name = "شوش",
                Slug = "شوش",
                ProvinceId = 13
            },
            new()
            {
                Id = 509,
                Name = "شوشتر",
                Slug = "شوشتر",
                ProvinceId = 13
            },
            new()
            {
                Id = 510,
                Name = "شیبان",
                Slug = "شیبان",
                ProvinceId = 13
            },
            new()
            {
                Id = 511,
                Name = "صالح شهر",
                Slug = "صالح-شهر",
                ProvinceId = 13
            },
            new()
            {
                Id = 512,
                Name = "صفی آباد",
                Slug = "خوزستان-صفی-آباد",
                ProvinceId = 13
            },
            new()
            {
                Id = 513,
                Name = "صیدون",
                Slug = "صیدون",
                ProvinceId = 13
            },
            new()
            {
                Id = 514,
                Name = "قلعه تل",
                Slug = "قلعه-تل",
                ProvinceId = 13
            },
            new()
            {
                Id = 515,
                Name = "قلعه خواجه",
                Slug = "قلعه-خواجه",
                ProvinceId = 13
            },
            new()
            {
                Id = 516,
                Name = "گتوند",
                Slug = "گتوند",
                ProvinceId = 13
            },
            new()
            {
                Id = 517,
                Name = "لالی",
                Slug = "لالی",
                ProvinceId = 13
            },
            new()
            {
                Id = 518,
                Name = "مسجدسلیمان",
                Slug = "مسجدسلیمان",
                ProvinceId = 13
            },
            new()
            {
                Id = 520,
                Name = "ملاثانی",
                Slug = "ملاثانی",
                ProvinceId = 13
            },
            new()
            {
                Id = 521,
                Name = "میانرود",
                Slug = "میانرود",
                ProvinceId = 13
            },
            new()
            {
                Id = 522,
                Name = "مینوشهر",
                Slug = "مینوشهر",
                ProvinceId = 13
            },
            new()
            {
                Id = 523,
                Name = "هفتگل",
                Slug = "هفتگل",
                ProvinceId = 13
            },
            new()
            {
                Id = 524,
                Name = "هندیجان",
                Slug = "هندیجان",
                ProvinceId = 13
            },
            new()
            {
                Id = 525,
                Name = "هویزه",
                Slug = "هویزه",
                ProvinceId = 13
            },
            new()
            {
                Id = 526,
                Name = "ویس",
                Slug = "ویس",
                ProvinceId = 13
            },
            new()
            {
                Id = 527,
                Name = "ابهر",
                Slug = "ابهر",
                ProvinceId = 14
            },
            new()
            {
                Id = 528,
                Name = "ارمغان خانه",
                Slug = "ارمغان-خانه",
                ProvinceId = 14
            },
            new()
            {
                Id = 529,
                Name = "آب بر",
                Slug = "آب-بر",
                ProvinceId = 14
            },
            new()
            {
                Id = 530,
                Name = "چورزق",
                Slug = "چورزق",
                ProvinceId = 14
            },
            new()
            {
                Id = 531,
                Name = "حلب",
                Slug = "حلب",
                ProvinceId = 14
            },
            new()
            {
                Id = 532,
                Name = "خرمدره",
                Slug = "خرمدره",
                ProvinceId = 14
            },
            new()
            {
                Id = 533,
                Name = "دندی",
                Slug = "دندی",
                ProvinceId = 14
            },
            new()
            {
                Id = 534,
                Name = "زرین آباد",
                Slug = "زرین-آباد",
                ProvinceId = 14
            },
            new()
            {
                Id = 535,
                Name = "زرین رود",
                Slug = "زرین-رود",
                ProvinceId = 14
            },
            new()
            {
                Id = 536,
                Name = "زنجان",
                Slug = "زنجان",
                ProvinceId = 14
            },
            new()
            {
                Id = 537,
                Name = "سجاس",
                Slug = "سجاس",
                ProvinceId = 14
            },
            new()
            {
                Id = 538,
                Name = "سلطانیه",
                Slug = "سلطانیه",
                ProvinceId = 14
            },
            new()
            {
                Id = 539,
                Name = "سهرورد",
                Slug = "سهرورد",
                ProvinceId = 14
            },
            new()
            {
                Id = 540,
                Name = "صائین قلعه",
                Slug = "صائین-قلعه",
                ProvinceId = 14
            },
            new()
            {
                Id = 541,
                Name = "قیدار",
                Slug = "قیدار",
                ProvinceId = 14
            },
            new()
            {
                Id = 542,
                Name = "گرماب",
                Slug = "گرماب",
                ProvinceId = 14
            },
            new()
            {
                Id = 543,
                Name = "ماه نشان",
                Slug = "ماه-نشان",
                ProvinceId = 14
            },
            new()
            {
                Id = 544,
                Name = "هیدج",
                Slug = "هیدج",
                ProvinceId = 14
            },
            new()
            {
                Id = 545,
                Name = "امیریه",
                Slug = "امیریه",
                ProvinceId = 15
            },
            new()
            {
                Id = 546,
                Name = "ایوانکی",
                Slug = "ایوانکی",
                ProvinceId = 15
            },
            new()
            {
                Id = 547,
                Name = "آرادان",
                Slug = "آرادان",
                ProvinceId = 15
            },
            new()
            {
                Id = 548,
                Name = "بسطام",
                Slug = "بسطام",
                ProvinceId = 15
            },
            new()
            {
                Id = 549,
                Name = "بیارجمند",
                Slug = "بیارجمند",
                ProvinceId = 15
            },
            new()
            {
                Id = 550,
                Name = "دامغان",
                Slug = "دامغان",
                ProvinceId = 15
            },
            new()
            {
                Id = 551,
                Name = "درجزین",
                Slug = "درجزین",
                ProvinceId = 15
            },
            new()
            {
                Id = 552,
                Name = "دیباج",
                Slug = "دیباج",
                ProvinceId = 15
            },
            new()
            {
                Id = 553,
                Name = "سرخه",
                Slug = "سرخه",
                ProvinceId = 15
            },
            new()
            {
                Id = 554,
                Name = "سمنان",
                Slug = "سمنان",
                ProvinceId = 15
            },
            new()
            {
                Id = 555,
                Name = "شاهرود",
                Slug = "شاهرود",
                ProvinceId = 15
            },
            new()
            {
                Id = 556,
                Name = "شهمیرزاد",
                Slug = "شهمیرزاد",
                ProvinceId = 15
            },
            new()
            {
                Id = 557,
                Name = "کلاته خیج",
                Slug = "کلاته-خیج",
                ProvinceId = 15
            },
            new()
            {
                Id = 558,
                Name = "گرمسار",
                Slug = "گرمسار",
                ProvinceId = 15
            },
            new()
            {
                Id = 559,
                Name = "مجن",
                Slug = "مجن",
                ProvinceId = 15
            },
            new()
            {
                Id = 560,
                Name = "مهدی شهر",
                Slug = "مهدی-شهر",
                ProvinceId = 15
            },
            new()
            {
                Id = 561,
                Name = "میامی",
                Slug = "میامی",
                ProvinceId = 15
            },
            new()
            {
                Id = 562,
                Name = "ادیمی",
                Slug = "ادیمی",
                ProvinceId = 16
            },
            new()
            {
                Id = 563,
                Name = "اسپکه",
                Slug = "اسپکه",
                ProvinceId = 16
            },
            new()
            {
                Id = 564,
                Name = "ایرانشهر",
                Slug = "ایرانشهر",
                ProvinceId = 16
            },
            new()
            {
                Id = 565,
                Name = "بزمان",
                Slug = "بزمان",
                ProvinceId = 16
            },
            new()
            {
                Id = 566,
                Name = "بمپور",
                Slug = "بمپور",
                ProvinceId = 16
            },
            new()
            {
                Id = 567,
                Name = "بنت",
                Slug = "بنت",
                ProvinceId = 16
            },
            new()
            {
                Id = 568,
                Name = "بنجار",
                Slug = "بنجار",
                ProvinceId = 16
            },
            new()
            {
                Id = 569,
                Name = "پیشین",
                Slug = "پیشین",
                ProvinceId = 16
            },
            new()
            {
                Id = 570,
                Name = "جالق",
                Slug = "جالق",
                ProvinceId = 16
            },
            new()
            {
                Id = 571,
                Name = "چابهار",
                Slug = "چابهار",
                ProvinceId = 16
            },
            new()
            {
                Id = 572,
                Name = "خاش",
                Slug = "خاش",
                ProvinceId = 16
            },
            new()
            {
                Id = 573,
                Name = "دوست محمد",
                Slug = "دوست-محمد",
                ProvinceId = 16
            },
            new()
            {
                Id = 574,
                Name = "راسک",
                Slug = "راسک",
                ProvinceId = 16
            },
            new()
            {
                Id = 575,
                Name = "زابل",
                Slug = "زابل",
                ProvinceId = 16
            },
            new()
            {
                Id = 576,
                Name = "زابلی",
                Slug = "زابلی",
                ProvinceId = 16
            },
            new()
            {
                Id = 577,
                Name = "زاهدان",
                Slug = "زاهدان",
                ProvinceId = 16
            },
            new()
            {
                Id = 578,
                Name = "زهک",
                Slug = "زهک",
                ProvinceId = 16
            },
            new()
            {
                Id = 579,
                Name = "سراوان",
                Slug = "سراوان",
                ProvinceId = 16
            },
            new()
            {
                Id = 580,
                Name = "سرباز",
                Slug = "سرباز",
                ProvinceId = 16
            },
            new()
            {
                Id = 581,
                Name = "سوران",
                Slug = "سوران",
                ProvinceId = 16
            },
            new()
            {
                Id = 582,
                Name = "سیرکان",
                Slug = "سیرکان",
                ProvinceId = 16
            },
            new()
            {
                Id = 583,
                Name = "علی اکبر",
                Slug = "علی-اکبر",
                ProvinceId = 16
            },
            new()
            {
                Id = 584,
                Name = "فنوج",
                Slug = "فنوج",
                ProvinceId = 16
            },
            new()
            {
                Id = 585,
                Name = "قصرقند",
                Slug = "قصرقند",
                ProvinceId = 16
            },
            new()
            {
                Id = 586,
                Name = "کنارک",
                Slug = "کنارک",
                ProvinceId = 16
            },
            new()
            {
                Id = 587,
                Name = "گشت",
                Slug = "گشت",
                ProvinceId = 16
            },
            new()
            {
                Id = 588,
                Name = "گلمورتی",
                Slug = "گلمورتی",
                ProvinceId = 16
            },
            new()
            {
                Id = 589,
                Name = "محمدان",
                Slug = "محمدان",
                ProvinceId = 16
            },
            new()
            {
                Id = 590,
                Name = "محمدآباد",
                Slug = "سیستان-و-بلوچستان-محمدآباد",
                ProvinceId = 16
            },
            new()
            {
                Id = 591,
                Name = "محمدی",
                Slug = "محمدی",
                ProvinceId = 16
            },
            new()
            {
                Id = 592,
                Name = "میرجاوه",
                Slug = "میرجاوه",
                ProvinceId = 16
            },
            new()
            {
                Id = 593,
                Name = "نصرت آباد",
                Slug = "نصرت-آباد",
                ProvinceId = 16
            },
            new()
            {
                Id = 594,
                Name = "نگور",
                Slug = "نگور",
                ProvinceId = 16
            },
            new()
            {
                Id = 595,
                Name = "نوک آباد",
                Slug = "نوک-آباد",
                ProvinceId = 16
            },
            new()
            {
                Id = 596,
                Name = "نیک شهر",
                Slug = "نیک-شهر",
                ProvinceId = 16
            },
            new()
            {
                Id = 597,
                Name = "هیدوچ",
                Slug = "هیدوچ",
                ProvinceId = 16
            },
            new()
            {
                Id = 598,
                Name = "اردکان",
                Slug = "فارس-اردکان",
                ProvinceId = 17
            },
            new()
            {
                Id = 599,
                Name = "ارسنجان",
                Slug = "ارسنجان",
                ProvinceId = 17
            },
            new()
            {
                Id = 600,
                Name = "استهبان",
                Slug = "استهبان",
                ProvinceId = 17
            },
            new()
            {
                Id = 601,
                Name = "اشکنان",
                Slug = "اشکنان",
                ProvinceId = 17
            },
            new()
            {
                Id = 602,
                Name = "افزر",
                Slug = "افزر",
                ProvinceId = 17
            },
            new()
            {
                Id = 603,
                Name = "اقلید",
                Slug = "اقلید",
                ProvinceId = 17
            },
            new()
            {
                Id = 604,
                Name = "امام شهر",
                Slug = "امام-شهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 605,
                Name = "اهل",
                Slug = "اهل",
                ProvinceId = 17
            },
            new()
            {
                Id = 606,
                Name = "اوز",
                Slug = "اوز",
                ProvinceId = 17
            },
            new()
            {
                Id = 607,
                Name = "ایج",
                Slug = "ایج",
                ProvinceId = 17
            },
            new()
            {
                Id = 608,
                Name = "ایزدخواست",
                Slug = "ایزدخواست",
                ProvinceId = 17
            },
            new()
            {
                Id = 609,
                Name = "آباده",
                Slug = "آباده",
                ProvinceId = 17
            },
            new()
            {
                Id = 610,
                Name = "آباده طشک",
                Slug = "آباده-طشک",
                ProvinceId = 17
            },
            new()
            {
                Id = 611,
                Name = "باب انار",
                Slug = "باب-انار",
                ProvinceId = 17
            },
            new()
            {
                Id = 612,
                Name = "بالاده",
                Slug = "فارس-بالاده",
                ProvinceId = 17
            },
            new()
            {
                Id = 613,
                Name = "بنارویه",
                Slug = "بنارویه",
                ProvinceId = 17
            },
            new()
            {
                Id = 614,
                Name = "بهمن",
                Slug = "بهمن",
                ProvinceId = 17
            },
            new()
            {
                Id = 615,
                Name = "بوانات",
                Slug = "بوانات",
                ProvinceId = 17
            },
            new()
            {
                Id = 616,
                Name = "بیرم",
                Slug = "بیرم",
                ProvinceId = 17
            },
            new()
            {
                Id = 617,
                Name = "بیضا",
                Slug = "بیضا",
                ProvinceId = 17
            },
            new()
            {
                Id = 618,
                Name = "جنت شهر",
                Slug = "جنت-شهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 619,
                Name = "جهرم",
                Slug = "جهرم",
                ProvinceId = 17
            },
            new()
            {
                Id = 620,
                Name = "جویم",
                Slug = "جویم",
                ProvinceId = 17
            },
            new()
            {
                Id = 621,
                Name = "زرین دشت",
                Slug = "زرین-دشت",
                ProvinceId = 17
            },
            new()
            {
                Id = 622,
                Name = "حسن آباد",
                Slug = "فارس-حسن-آباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 623,
                Name = "خان زنیان",
                Slug = "خان-زنیان",
                ProvinceId = 17
            },
            new()
            {
                Id = 624,
                Name = "خاوران",
                Slug = "خاوران",
                ProvinceId = 17
            },
            new()
            {
                Id = 625,
                Name = "خرامه",
                Slug = "خرامه",
                ProvinceId = 17
            },
            new()
            {
                Id = 626,
                Name = "خشت",
                Slug = "خشت",
                ProvinceId = 17
            },
            new()
            {
                Id = 627,
                Name = "خنج",
                Slug = "خنج",
                ProvinceId = 17
            },
            new()
            {
                Id = 628,
                Name = "خور",
                Slug = "فارس-خور",
                ProvinceId = 17
            },
            new()
            {
                Id = 629,
                Name = "داراب",
                Slug = "داراب",
                ProvinceId = 17
            },
            new()
            {
                Id = 630,
                Name = "داریان",
                Slug = "داریان",
                ProvinceId = 17
            },
            new()
            {
                Id = 631,
                Name = "دبیران",
                Slug = "دبیران",
                ProvinceId = 17
            },
            new()
            {
                Id = 632,
                Name = "دژکرد",
                Slug = "دژکرد",
                ProvinceId = 17
            },
            new()
            {
                Id = 633,
                Name = "دهرم",
                Slug = "دهرم",
                ProvinceId = 17
            },
            new()
            {
                Id = 634,
                Name = "دوبرجی",
                Slug = "دوبرجی",
                ProvinceId = 17
            },
            new()
            {
                Id = 635,
                Name = "رامجرد",
                Slug = "رامجرد",
                ProvinceId = 17
            },
            new()
            {
                Id = 636,
                Name = "رونیز",
                Slug = "رونیز",
                ProvinceId = 17
            },
            new()
            {
                Id = 637,
                Name = "زاهدشهر",
                Slug = "زاهدشهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 638,
                Name = "زرقان",
                Slug = "زرقان",
                ProvinceId = 17
            },
            new()
            {
                Id = 639,
                Name = "سده",
                Slug = "سده",
                ProvinceId = 17
            },
            new()
            {
                Id = 640,
                Name = "سروستان",
                Slug = "سروستان",
                ProvinceId = 17
            },
            new()
            {
                Id = 641,
                Name = "سعادت شهر",
                Slug = "سعادت-شهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 642,
                Name = "سورمق",
                Slug = "سورمق",
                ProvinceId = 17
            },
            new()
            {
                Id = 643,
                Name = "سیدان",
                Slug = "سیدان",
                ProvinceId = 17
            },
            new()
            {
                Id = 644,
                Name = "ششده",
                Slug = "ششده",
                ProvinceId = 17
            },
            new()
            {
                Id = 645,
                Name = "شهرپیر",
                Slug = "شهرپیر",
                ProvinceId = 17
            },
            new()
            {
                Id = 646,
                Name = "شهرصدرا",
                Slug = "شهرصدرا",
                ProvinceId = 17
            },
            new()
            {
                Id = 647,
                Name = "شیراز",
                Slug = "شیراز",
                ProvinceId = 17
            },
            new()
            {
                Id = 648,
                Name = "صغاد",
                Slug = "صغاد",
                ProvinceId = 17
            },
            new()
            {
                Id = 649,
                Name = "صفاشهر",
                Slug = "صفاشهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 650,
                Name = "علامرودشت",
                Slug = "علامرودشت",
                ProvinceId = 17
            },
            new()
            {
                Id = 651,
                Name = "فدامی",
                Slug = "فدامی",
                ProvinceId = 17
            },
            new()
            {
                Id = 652,
                Name = "فراشبند",
                Slug = "فراشبند",
                ProvinceId = 17
            },
            new()
            {
                Id = 653,
                Name = "فسا",
                Slug = "فسا",
                ProvinceId = 17
            },
            new()
            {
                Id = 654,
                Name = "فیروزآباد",
                Slug = "فارس-فیروزآباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 655,
                Name = "قائمیه",
                Slug = "قائمیه",
                ProvinceId = 17
            },
            new()
            {
                Id = 656,
                Name = "قادرآباد",
                Slug = "قادرآباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 657,
                Name = "قطب آباد",
                Slug = "قطب-آباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 658,
                Name = "قطرویه",
                Slug = "قطرویه",
                ProvinceId = 17
            },
            new()
            {
                Id = 659,
                Name = "قیر",
                Slug = "قیر",
                ProvinceId = 17
            },
            new()
            {
                Id = 660,
                Name = "کارزین (فتح آباد)",
                Slug = "کارزین-فتح-آباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 661,
                Name = "کازرون",
                Slug = "کازرون",
                ProvinceId = 17
            },
            new()
            {
                Id = 662,
                Name = "کامفیروز",
                Slug = "کامفیروز",
                ProvinceId = 17
            },
            new()
            {
                Id = 663,
                Name = "کره ای",
                Slug = "کره-ای",
                ProvinceId = 17
            },
            new()
            {
                Id = 664,
                Name = "کنارتخته",
                Slug = "کنارتخته",
                ProvinceId = 17
            },
            new()
            {
                Id = 665,
                Name = "کوار",
                Slug = "کوار",
                ProvinceId = 17
            },
            new()
            {
                Id = 666,
                Name = "گراش",
                Slug = "گراش",
                ProvinceId = 17
            },
            new()
            {
                Id = 667,
                Name = "گله دار",
                Slug = "گله-دار",
                ProvinceId = 17
            },
            new()
            {
                Id = 668,
                Name = "لار",
                Slug = "لار",
                ProvinceId = 17
            },
            new()
            {
                Id = 669,
                Name = "لامرد",
                Slug = "لامرد",
                ProvinceId = 17
            },
            new()
            {
                Id = 670,
                Name = "لپویی",
                Slug = "لپویی",
                ProvinceId = 17
            },
            new()
            {
                Id = 671,
                Name = "لطیفی",
                Slug = "لطیفی",
                ProvinceId = 17
            },
            new()
            {
                Id = 672,
                Name = "مبارک آباددیز",
                Slug = "مبارک-آباددیز",
                ProvinceId = 17
            },
            new()
            {
                Id = 673,
                Name = "مرودشت",
                Slug = "مرودشت",
                ProvinceId = 17
            },
            new()
            {
                Id = 674,
                Name = "مشکان",
                Slug = "مشکان",
                ProvinceId = 17
            },
            new()
            {
                Id = 675,
                Name = "مصیری",
                Slug = "مصیری",
                ProvinceId = 17
            },
            new()
            {
                Id = 676,
                Name = "مهر",
                Slug = "مهر",
                ProvinceId = 17
            },
            new()
            {
                Id = 677,
                Name = "میمند",
                Slug = "میمند",
                ProvinceId = 17
            },
            new()
            {
                Id = 678,
                Name = "نوبندگان",
                Slug = "نوبندگان",
                ProvinceId = 17
            },
            new()
            {
                Id = 679,
                Name = "نوجین",
                Slug = "نوجین",
                ProvinceId = 17
            },
            new()
            {
                Id = 680,
                Name = "نودان",
                Slug = "نودان",
                ProvinceId = 17
            },
            new()
            {
                Id = 681,
                Name = "نورآباد",
                Slug = "فارس-نورآباد",
                ProvinceId = 17
            },
            new()
            {
                Id = 682,
                Name = "نی ریز",
                Slug = "نی-ریز",
                ProvinceId = 17
            },
            new()
            {
                Id = 683,
                Name = "وراوی",
                Slug = "وراوی",
                ProvinceId = 17
            },
            new()
            {
                Id = 684,
                Name = "ارداق",
                Slug = "ارداق",
                ProvinceId = 18
            },
            new()
            {
                Id = 685,
                Name = "اسفرورین",
                Slug = "اسفرورین",
                ProvinceId = 18
            },
            new()
            {
                Id = 686,
                Name = "اقبالیه",
                Slug = "اقبالیه",
                ProvinceId = 18
            },
            new()
            {
                Id = 687,
                Name = "الوند",
                Slug = "الوند",
                ProvinceId = 18
            },
            new()
            {
                Id = 688,
                Name = "آبگرم",
                Slug = "آبگرم",
                ProvinceId = 18
            },
            new()
            {
                Id = 689,
                Name = "آبیک",
                Slug = "آبیک",
                ProvinceId = 18
            },
            new()
            {
                Id = 690,
                Name = "آوج",
                Slug = "آوج",
                ProvinceId = 18
            },
            new()
            {
                Id = 691,
                Name = "بوئین زهرا",
                Slug = "بوئین-زهرا",
                ProvinceId = 18
            },
            new()
            {
                Id = 692,
                Name = "بیدستان",
                Slug = "بیدستان",
                ProvinceId = 18
            },
            new()
            {
                Id = 693,
                Name = "تاکستان",
                Slug = "تاکستان",
                ProvinceId = 18
            },
            new()
            {
                Id = 694,
                Name = "خاکعلی",
                Slug = "خاکعلی",
                ProvinceId = 18
            },
            new()
            {
                Id = 695,
                Name = "خرمدشت",
                Slug = "خرمدشت",
                ProvinceId = 18
            },
            new()
            {
                Id = 696,
                Name = "دانسفهان",
                Slug = "دانسفهان",
                ProvinceId = 18
            },
            new()
            {
                Id = 697,
                Name = "رازمیان",
                Slug = "رازمیان",
                ProvinceId = 18
            },
            new()
            {
                Id = 698,
                Name = "سگزآباد",
                Slug = "سگزآباد",
                ProvinceId = 18
            },
            new()
            {
                Id = 699,
                Name = "سیردان",
                Slug = "سیردان",
                ProvinceId = 18
            },
            new()
            {
                Id = 700,
                Name = "شال",
                Slug = "شال",
                ProvinceId = 18
            },
            new()
            {
                Id = 701,
                Name = "شریفیه",
                Slug = "شریفیه",
                ProvinceId = 18
            },
            new()
            {
                Id = 702,
                Name = "ضیاآباد",
                Slug = "ضیاآباد",
                ProvinceId = 18
            },
            new()
            {
                Id = 703,
                Name = "قزوین",
                Slug = "قزوین",
                ProvinceId = 18
            },
            new()
            {
                Id = 704,
                Name = "کوهین",
                Slug = "کوهین",
                ProvinceId = 18
            },
            new()
            {
                Id = 705,
                Name = "محمدیه",
                Slug = "محمدیه",
                ProvinceId = 18
            },
            new()
            {
                Id = 706,
                Name = "محمودآباد نمونه",
                Slug = "محمودآباد-نمونه",
                ProvinceId = 18
            },
            new()
            {
                Id = 707,
                Name = "معلم کلایه",
                Slug = "معلم-کلایه",
                ProvinceId = 18
            },
            new()
            {
                Id = 708,
                Name = "نرجه",
                Slug = "نرجه",
                ProvinceId = 18
            },
            new()
            {
                Id = 709,
                Name = "جعفریه",
                Slug = "جعفریه",
                ProvinceId = 19
            },
            new()
            {
                Id = 710,
                Name = "دستجرد",
                Slug = "دستجرد",
                ProvinceId = 19
            },
            new()
            {
                Id = 711,
                Name = "سلفچگان",
                Slug = "سلفچگان",
                ProvinceId = 19
            },
            new()
            {
                Id = 712,
                Name = "قم",
                Slug = "قم",
                ProvinceId = 19
            },
            new()
            {
                Id = 713,
                Name = "قنوات",
                Slug = "قنوات",
                ProvinceId = 19
            },
            new()
            {
                Id = 714,
                Name = "کهک",
                Slug = "کهک",
                ProvinceId = 19
            },
            new()
            {
                Id = 715,
                Name = "آرمرده",
                Slug = "آرمرده",
                ProvinceId = 20
            },
            new()
            {
                Id = 716,
                Name = "بابارشانی",
                Slug = "بابارشانی",
                ProvinceId = 20
            },
            new()
            {
                Id = 717,
                Name = "بانه",
                Slug = "بانه",
                ProvinceId = 20
            },
            new()
            {
                Id = 718,
                Name = "بلبان آباد",
                Slug = "بلبان-آباد",
                ProvinceId = 20
            },
            new()
            {
                Id = 719,
                Name = "بوئین سفلی",
                Slug = "بوئین-سفلی",
                ProvinceId = 20
            },
            new()
            {
                Id = 720,
                Name = "بیجار",
                Slug = "بیجار",
                ProvinceId = 20
            },
            new()
            {
                Id = 721,
                Name = "چناره",
                Slug = "چناره",
                ProvinceId = 20
            },
            new()
            {
                Id = 722,
                Name = "دزج",
                Slug = "دزج",
                ProvinceId = 20
            },
            new()
            {
                Id = 723,
                Name = "دلبران",
                Slug = "دلبران",
                ProvinceId = 20
            },
            new()
            {
                Id = 724,
                Name = "دهگلان",
                Slug = "دهگلان",
                ProvinceId = 20
            },
            new()
            {
                Id = 725,
                Name = "دیواندره",
                Slug = "دیواندره",
                ProvinceId = 20
            },
            new()
            {
                Id = 726,
                Name = "زرینه",
                Slug = "زرینه",
                ProvinceId = 20
            },
            new()
            {
                Id = 727,
                Name = "سروآباد",
                Slug = "سروآباد",
                ProvinceId = 20
            },
            new()
            {
                Id = 728,
                Name = "سریش آباد",
                Slug = "سریش-آباد",
                ProvinceId = 20
            },
            new()
            {
                Id = 729,
                Name = "سقز",
                Slug = "سقز",
                ProvinceId = 20
            },
            new()
            {
                Id = 730,
                Name = "سنندج",
                Slug = "سنندج",
                ProvinceId = 20
            },
            new()
            {
                Id = 731,
                Name = "شویشه",
                Slug = "شویشه",
                ProvinceId = 20
            },
            new()
            {
                Id = 732,
                Name = "صاحب",
                Slug = "صاحب",
                ProvinceId = 20
            },
            new()
            {
                Id = 733,
                Name = "قروه",
                Slug = "قروه",
                ProvinceId = 20
            },
            new()
            {
                Id = 734,
                Name = "کامیاران",
                Slug = "کامیاران",
                ProvinceId = 20
            },
            new()
            {
                Id = 735,
                Name = "کانی دینار",
                Slug = "کانی-دینار",
                ProvinceId = 20
            },
            new()
            {
                Id = 736,
                Name = "کانی سور",
                Slug = "کانی-سور",
                ProvinceId = 20
            },
            new()
            {
                Id = 737,
                Name = "مریوان",
                Slug = "مریوان",
                ProvinceId = 20
            },
            new()
            {
                Id = 738,
                Name = "موچش",
                Slug = "موچش",
                ProvinceId = 20
            },
            new()
            {
                Id = 739,
                Name = "یاسوکند",
                Slug = "یاسوکند",
                ProvinceId = 20
            },
            new()
            {
                Id = 740,
                Name = "اختیارآباد",
                Slug = "اختیارآباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 741,
                Name = "ارزوئیه",
                Slug = "ارزوئیه",
                ProvinceId = 21
            },
            new()
            {
                Id = 742,
                Name = "امین شهر",
                Slug = "امین-شهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 743,
                Name = "انار",
                Slug = "انار",
                ProvinceId = 21
            },
            new()
            {
                Id = 744,
                Name = "اندوهجرد",
                Slug = "اندوهجرد",
                ProvinceId = 21
            },
            new()
            {
                Id = 745,
                Name = "باغین",
                Slug = "باغین",
                ProvinceId = 21
            },
            new()
            {
                Id = 746,
                Name = "بافت",
                Slug = "بافت",
                ProvinceId = 21
            },
            new()
            {
                Id = 747,
                Name = "بردسیر",
                Slug = "بردسیر",
                ProvinceId = 21
            },
            new()
            {
                Id = 748,
                Name = "بروات",
                Slug = "بروات",
                ProvinceId = 21
            },
            new()
            {
                Id = 749,
                Name = "بزنجان",
                Slug = "بزنجان",
                ProvinceId = 21
            },
            new()
            {
                Id = 750,
                Name = "بم",
                Slug = "بم",
                ProvinceId = 21
            },
            new()
            {
                Id = 751,
                Name = "بهرمان",
                Slug = "بهرمان",
                ProvinceId = 21
            },
            new()
            {
                Id = 752,
                Name = "پاریز",
                Slug = "پاریز",
                ProvinceId = 21
            },
            new()
            {
                Id = 753,
                Name = "جبالبارز",
                Slug = "جبالبارز",
                ProvinceId = 21
            },
            new()
            {
                Id = 754,
                Name = "جوپار",
                Slug = "جوپار",
                ProvinceId = 21
            },
            new()
            {
                Id = 755,
                Name = "جوزم",
                Slug = "جوزم",
                ProvinceId = 21
            },
            new()
            {
                Id = 756,
                Name = "جیرفت",
                Slug = "جیرفت",
                ProvinceId = 21
            },
            new()
            {
                Id = 757,
                Name = "چترود",
                Slug = "چترود",
                ProvinceId = 21
            },
            new()
            {
                Id = 758,
                Name = "خاتون آباد",
                Slug = "خاتون-آباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 759,
                Name = "خانوک",
                Slug = "خانوک",
                ProvinceId = 21
            },
            new()
            {
                Id = 760,
                Name = "خورسند",
                Slug = "خورسند",
                ProvinceId = 21
            },
            new()
            {
                Id = 761,
                Name = "درب بهشت",
                Slug = "درب-بهشت",
                ProvinceId = 21
            },
            new()
            {
                Id = 762,
                Name = "دهج",
                Slug = "دهج",
                ProvinceId = 21
            },
            new()
            {
                Id = 763,
                Name = "رابر",
                Slug = "رابر",
                ProvinceId = 21
            },
            new()
            {
                Id = 764,
                Name = "راور",
                Slug = "راور",
                ProvinceId = 21
            },
            new()
            {
                Id = 765,
                Name = "راین",
                Slug = "راین",
                ProvinceId = 21
            },
            new()
            {
                Id = 766,
                Name = "رفسنجان",
                Slug = "رفسنجان",
                ProvinceId = 21
            },
            new()
            {
                Id = 767,
                Name = "رودبار",
                Slug = "کرمان-رودبار",
                ProvinceId = 21
            },
            new()
            {
                Id = 768,
                Name = "ریحان شهر",
                Slug = "ریحان-شهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 769,
                Name = "زرند",
                Slug = "زرند",
                ProvinceId = 21
            },
            new()
            {
                Id = 770,
                Name = "زنگی آباد",
                Slug = "زنگی-آباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 771,
                Name = "زیدآباد",
                Slug = "زیدآباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 772,
                Name = "سیرجان",
                Slug = "سیرجان",
                ProvinceId = 21
            },
            new()
            {
                Id = 773,
                Name = "شهداد",
                Slug = "شهداد",
                ProvinceId = 21
            },
            new()
            {
                Id = 774,
                Name = "شهربابک",
                Slug = "شهربابک",
                ProvinceId = 21
            },
            new()
            {
                Id = 775,
                Name = "صفائیه",
                Slug = "صفائیه",
                ProvinceId = 21
            },
            new()
            {
                Id = 776,
                Name = "عنبرآباد",
                Slug = "عنبرآباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 777,
                Name = "فاریاب",
                Slug = "فاریاب",
                ProvinceId = 21
            },
            new()
            {
                Id = 778,
                Name = "فهرج",
                Slug = "فهرج",
                ProvinceId = 21
            },
            new()
            {
                Id = 779,
                Name = "قلعه گنج",
                Slug = "قلعه-گنج",
                ProvinceId = 21
            },
            new()
            {
                Id = 780,
                Name = "کاظم آباد",
                Slug = "کاظم-آباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 781,
                Name = "کرمان",
                Slug = "کرمان",
                ProvinceId = 21
            },
            new()
            {
                Id = 782,
                Name = "کشکوئیه",
                Slug = "کشکوئیه",
                ProvinceId = 21
            },
            new()
            {
                Id = 783,
                Name = "کهنوج",
                Slug = "کهنوج",
                ProvinceId = 21
            },
            new()
            {
                Id = 784,
                Name = "کوهبنان",
                Slug = "کوهبنان",
                ProvinceId = 21
            },
            new()
            {
                Id = 785,
                Name = "کیانشهر",
                Slug = "کیانشهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 786,
                Name = "گلباف",
                Slug = "گلباف",
                ProvinceId = 21
            },
            new()
            {
                Id = 787,
                Name = "گلزار",
                Slug = "گلزار",
                ProvinceId = 21
            },
            new()
            {
                Id = 788,
                Name = "لاله زار",
                Slug = "لاله-زار",
                ProvinceId = 21
            },
            new()
            {
                Id = 789,
                Name = "ماهان",
                Slug = "ماهان",
                ProvinceId = 21
            },
            new()
            {
                Id = 790,
                Name = "محمدآباد",
                Slug = "کرمان-محمدآباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 791,
                Name = "محی آباد",
                Slug = "محی-آباد",
                ProvinceId = 21
            },
            new()
            {
                Id = 792,
                Name = "مردهک",
                Slug = "مردهک",
                ProvinceId = 21
            },
            new()
            {
                Id = 793,
                Name = "مس سرچشمه",
                Slug = "مس-سرچشمه",
                ProvinceId = 21
            },
            new()
            {
                Id = 794,
                Name = "منوجان",
                Slug = "منوجان",
                ProvinceId = 21
            },
            new()
            {
                Id = 795,
                Name = "نجف شهر",
                Slug = "نجف-شهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 796,
                Name = "نرماشیر",
                Slug = "نرماشیر",
                ProvinceId = 21
            },
            new()
            {
                Id = 797,
                Name = "نظام شهر",
                Slug = "نظام-شهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 798,
                Name = "نگار",
                Slug = "نگار",
                ProvinceId = 21
            },
            new()
            {
                Id = 799,
                Name = "نودژ",
                Slug = "نودژ",
                ProvinceId = 21
            },
            new()
            {
                Id = 800,
                Name = "هجدک",
                Slug = "هجدک",
                ProvinceId = 21
            },
            new()
            {
                Id = 801,
                Name = "یزدان شهر",
                Slug = "یزدان-شهر",
                ProvinceId = 21
            },
            new()
            {
                Id = 802,
                Name = "ازگله",
                Slug = "ازگله",
                ProvinceId = 22
            },
            new()
            {
                Id = 803,
                Name = "اسلام آباد غرب",
                Slug = "اسلام-آباد-غرب",
                ProvinceId = 22
            },
            new()
            {
                Id = 804,
                Name = "باینگان",
                Slug = "باینگان",
                ProvinceId = 22
            },
            new()
            {
                Id = 805,
                Name = "بیستون",
                Slug = "بیستون",
                ProvinceId = 22
            },
            new()
            {
                Id = 806,
                Name = "پاوه",
                Slug = "پاوه",
                ProvinceId = 22
            },
            new()
            {
                Id = 807,
                Name = "تازه آباد",
                Slug = "تازه-آباد",
                ProvinceId = 22
            },
            new()
            {
                Id = 808,
                Name = "جوان رود",
                Slug = "جوان-رود",
                ProvinceId = 22
            },
            new()
            {
                Id = 809,
                Name = "حمیل",
                Slug = "حمیل",
                ProvinceId = 22
            },
            new()
            {
                Id = 810,
                Name = "ماهیدشت",
                Slug = "ماهیدشت",
                ProvinceId = 22
            },
            new()
            {
                Id = 811,
                Name = "روانسر",
                Slug = "روانسر",
                ProvinceId = 22
            },
            new()
            {
                Id = 812,
                Name = "سرپل ذهاب",
                Slug = "سرپل-ذهاب",
                ProvinceId = 22
            },
            new()
            {
                Id = 813,
                Name = "سرمست",
                Slug = "سرمست",
                ProvinceId = 22
            },
            new()
            {
                Id = 814,
                Name = "سطر",
                Slug = "سطر",
                ProvinceId = 22
            },
            new()
            {
                Id = 815,
                Name = "سنقر",
                Slug = "سنقر",
                ProvinceId = 22
            },
            new()
            {
                Id = 816,
                Name = "سومار",
                Slug = "سومار",
                ProvinceId = 22
            },
            new()
            {
                Id = 817,
                Name = "شاهو",
                Slug = "شاهو",
                ProvinceId = 22
            },
            new()
            {
                Id = 818,
                Name = "صحنه",
                Slug = "صحنه",
                ProvinceId = 22
            },
            new()
            {
                Id = 819,
                Name = "قصرشیرین",
                Slug = "قصرشیرین",
                ProvinceId = 22
            },
            new()
            {
                Id = 820,
                Name = "کرمانشاه",
                Slug = "کرمانشاه",
                ProvinceId = 22
            },
            new()
            {
                Id = 821,
                Name = "کرندغرب",
                Slug = "کرندغرب",
                ProvinceId = 22
            },
            new()
            {
                Id = 822,
                Name = "کنگاور",
                Slug = "کنگاور",
                ProvinceId = 22
            },
            new()
            {
                Id = 823,
                Name = "کوزران",
                Slug = "کوزران",
                ProvinceId = 22
            },
            new()
            {
                Id = 824,
                Name = "گهواره",
                Slug = "گهواره",
                ProvinceId = 22
            },
            new()
            {
                Id = 825,
                Name = "گیلانغرب",
                Slug = "گیلانغرب",
                ProvinceId = 22
            },
            new()
            {
                Id = 826,
                Name = "میان راهان",
                Slug = "میان-راهان",
                ProvinceId = 22
            },
            new()
            {
                Id = 827,
                Name = "نودشه",
                Slug = "نودشه",
                ProvinceId = 22
            },
            new()
            {
                Id = 828,
                Name = "نوسود",
                Slug = "نوسود",
                ProvinceId = 22
            },
            new()
            {
                Id = 829,
                Name = "هرسین",
                Slug = "هرسین",
                ProvinceId = 22
            },
            new()
            {
                Id = 830,
                Name = "هلشی",
                Slug = "هلشی",
                ProvinceId = 22
            },
            new()
            {
                Id = 831,
                Name = "باشت",
                Slug = "باشت",
                ProvinceId = 23
            },
            new()
            {
                Id = 832,
                Name = "پاتاوه",
                Slug = "پاتاوه",
                ProvinceId = 23
            },
            new()
            {
                Id = 833,
                Name = "چرام",
                Slug = "چرام",
                ProvinceId = 23
            },
            new()
            {
                Id = 834,
                Name = "چیتاب",
                Slug = "چیتاب",
                ProvinceId = 23
            },
            new()
            {
                Id = 835,
                Name = "دهدشت",
                Slug = "دهدشت",
                ProvinceId = 23
            },
            new()
            {
                Id = 836,
                Name = "دوگنبدان",
                Slug = "دوگنبدان",
                ProvinceId = 23
            },
            new()
            {
                Id = 837,
                Name = "دیشموک",
                Slug = "دیشموک",
                ProvinceId = 23
            },
            new()
            {
                Id = 838,
                Name = "سوق",
                Slug = "سوق",
                ProvinceId = 23
            },
            new()
            {
                Id = 839,
                Name = "سی سخت",
                Slug = "سی-سخت",
                ProvinceId = 23
            },
            new()
            {
                Id = 840,
                Name = "قلعه رئیسی",
                Slug = "قلعه-رئیسی",
                ProvinceId = 23
            },
            new()
            {
                Id = 841,
                Name = "گراب سفلی",
                Slug = "گراب-سفلی",
                ProvinceId = 23
            },
            new()
            {
                Id = 842,
                Name = "لنده",
                Slug = "لنده",
                ProvinceId = 23
            },
            new()
            {
                Id = 843,
                Name = "لیکک",
                Slug = "لیکک",
                ProvinceId = 23
            },
            new()
            {
                Id = 844,
                Name = "مادوان",
                Slug = "مادوان",
                ProvinceId = 23
            },
            new()
            {
                Id = 845,
                Name = "مارگون",
                Slug = "مارگون",
                ProvinceId = 23
            },
            new()
            {
                Id = 846,
                Name = "یاسوج",
                Slug = "یاسوج",
                ProvinceId = 23
            },
            new()
            {
                Id = 847,
                Name = "انبارآلوم",
                Slug = "انبارآلوم",
                ProvinceId = 24
            },
            new()
            {
                Id = 848,
                Name = "اینچه برون",
                Slug = "اینچه-برون",
                ProvinceId = 24
            },
            new()
            {
                Id = 849,
                Name = "آزادشهر",
                Slug = "آزادشهر",
                ProvinceId = 24
            },
            new()
            {
                Id = 850,
                Name = "آق قلا",
                Slug = "آق-قلا",
                ProvinceId = 24
            },
            new()
            {
                Id = 851,
                Name = "بندرترکمن",
                Slug = "بندرترکمن",
                ProvinceId = 24
            },
            new()
            {
                Id = 852,
                Name = "بندرگز",
                Slug = "بندرگز",
                ProvinceId = 24
            },
            new()
            {
                Id = 853,
                Name = "جلین",
                Slug = "جلین",
                ProvinceId = 24
            },
            new()
            {
                Id = 854,
                Name = "خان ببین",
                Slug = "خان-ببین",
                ProvinceId = 24
            },
            new()
            {
                Id = 855,
                Name = "دلند",
                Slug = "دلند",
                ProvinceId = 24
            },
            new()
            {
                Id = 856,
                Name = "رامیان",
                Slug = "رامیان",
                ProvinceId = 24
            },
            new()
            {
                Id = 857,
                Name = "سرخنکلاته",
                Slug = "سرخنکلاته",
                ProvinceId = 24
            },
            new()
            {
                Id = 858,
                Name = "سیمین شهر",
                Slug = "سیمین-شهر",
                ProvinceId = 24
            },
            new()
            {
                Id = 859,
                Name = "علی آباد کتول",
                Slug = "علی-آباد-کتول",
                ProvinceId = 24
            },
            new()
            {
                Id = 860,
                Name = "فاضل آباد",
                Slug = "فاضل-آباد",
                ProvinceId = 24
            },
            new()
            {
                Id = 861,
                Name = "کردکوی",
                Slug = "کردکوی",
                ProvinceId = 24
            },
            new()
            {
                Id = 862,
                Name = "کلاله",
                Slug = "کلاله",
                ProvinceId = 24
            },
            new()
            {
                Id = 863,
                Name = "گالیکش",
                Slug = "گالیکش",
                ProvinceId = 24
            },
            new()
            {
                Id = 864,
                Name = "گرگان",
                Slug = "گرگان",
                ProvinceId = 24
            },
            new()
            {
                Id = 865,
                Name = "گمیش تپه",
                Slug = "گمیش-تپه",
                ProvinceId = 24
            },
            new()
            {
                Id = 866,
                Name = "گنبدکاووس",
                Slug = "گنبدکاووس",
                ProvinceId = 24
            },
            new()
            {
                Id = 867,
                Name = "مراوه",
                Slug = "مراوه",
                ProvinceId = 24
            },
            new()
            {
                Id = 868,
                Name = "مینودشت",
                Slug = "مینودشت",
                ProvinceId = 24
            },
            new()
            {
                Id = 869,
                Name = "نگین شهر",
                Slug = "نگین-شهر",
                ProvinceId = 24
            },
            new()
            {
                Id = 870,
                Name = "نوده خاندوز",
                Slug = "نوده-خاندوز",
                ProvinceId = 24
            },
            new()
            {
                Id = 871,
                Name = "نوکنده",
                Slug = "نوکنده",
                ProvinceId = 24
            },
            new()
            {
                Id = 872,
                Name = "ازنا",
                Slug = "ازنا",
                ProvinceId = 25
            },
            new()
            {
                Id = 873,
                Name = "اشترینان",
                Slug = "اشترینان",
                ProvinceId = 25
            },
            new()
            {
                Id = 874,
                Name = "الشتر",
                Slug = "الشتر",
                ProvinceId = 25
            },
            new()
            {
                Id = 875,
                Name = "الیگودرز",
                Slug = "الیگودرز",
                ProvinceId = 25
            },
            new()
            {
                Id = 876,
                Name = "بروجرد",
                Slug = "بروجرد",
                ProvinceId = 25
            },
            new()
            {
                Id = 877,
                Name = "پلدختر",
                Slug = "پلدختر",
                ProvinceId = 25
            },
            new()
            {
                Id = 878,
                Name = "چالانچولان",
                Slug = "چالانچولان",
                ProvinceId = 25
            },
            new()
            {
                Id = 879,
                Name = "چغلوندی",
                Slug = "چغلوندی",
                ProvinceId = 25
            },
            new()
            {
                Id = 880,
                Name = "چقابل",
                Slug = "چقابل",
                ProvinceId = 25
            },
            new()
            {
                Id = 881,
                Name = "خرم آباد",
                Slug = "لرستان-خرم-آباد",
                ProvinceId = 25
            },
            new()
            {
                Id = 882,
                Name = "درب گنبد",
                Slug = "درب-گنبد",
                ProvinceId = 25
            },
            new()
            {
                Id = 883,
                Name = "دورود",
                Slug = "دورود",
                ProvinceId = 25
            },
            new()
            {
                Id = 884,
                Name = "زاغه",
                Slug = "زاغه",
                ProvinceId = 25
            },
            new()
            {
                Id = 885,
                Name = "سپیددشت",
                Slug = "سپیددشت",
                ProvinceId = 25
            },
            new()
            {
                Id = 886,
                Name = "سراب دوره",
                Slug = "سراب-دوره",
                ProvinceId = 25
            },
            new()
            {
                Id = 887,
                Name = "فیروزآباد",
                Slug = "لرستان-فیروزآباد",
                ProvinceId = 25
            },
            new()
            {
                Id = 888,
                Name = "کونانی",
                Slug = "کونانی",
                ProvinceId = 25
            },
            new()
            {
                Id = 889,
                Name = "کوهدشت",
                Slug = "کوهدشت",
                ProvinceId = 25
            },
            new()
            {
                Id = 890,
                Name = "گراب",
                Slug = "گراب",
                ProvinceId = 25
            },
            new()
            {
                Id = 891,
                Name = "معمولان",
                Slug = "معمولان",
                ProvinceId = 25
            },
            new()
            {
                Id = 892,
                Name = "مومن آباد",
                Slug = "مومن-آباد",
                ProvinceId = 25
            },
            new()
            {
                Id = 893,
                Name = "نورآباد",
                Slug = "لرستان-نورآباد",
                ProvinceId = 25
            },
            new()
            {
                Id = 894,
                Name = "ویسیان",
                Slug = "ویسیان",
                ProvinceId = 25
            },
            new()
            {
                Id = 895,
                Name = "احمدسرگوراب",
                Slug = "احمدسرگوراب",
                ProvinceId = 26
            },
            new()
            {
                Id = 896,
                Name = "اسالم",
                Slug = "اسالم",
                ProvinceId = 26
            },
            new()
            {
                Id = 897,
                Name = "اطاقور",
                Slug = "اطاقور",
                ProvinceId = 26
            },
            new()
            {
                Id = 898,
                Name = "املش",
                Slug = "املش",
                ProvinceId = 26
            },
            new()
            {
                Id = 899,
                Name = "آستارا",
                Slug = "آستارا",
                ProvinceId = 26
            },
            new()
            {
                Id = 900,
                Name = "آستانه اشرفیه",
                Slug = "آستانه-اشرفیه",
                ProvinceId = 26
            },
            new()
            {
                Id = 901,
                Name = "بازار جمعه",
                Slug = "بازار-جمعه",
                ProvinceId = 26
            },
            new()
            {
                Id = 902,
                Name = "بره سر",
                Slug = "بره-سر",
                ProvinceId = 26
            },
            new()
            {
                Id = 903,
                Name = "بندرانزلی",
                Slug = "بندرانزلی",
                ProvinceId = 26
            },
            new()
            {
                Id = 906,
                Name = "پره سر",
                Slug = "پره-سر",
                ProvinceId = 26
            },
            new()
            {
                Id = 907,
                Name = "تالش",
                Slug = "تالش",
                ProvinceId = 26
            },
            new()
            {
                Id = 908,
                Name = "توتکابن",
                Slug = "توتکابن",
                ProvinceId = 26
            },
            new()
            {
                Id = 909,
                Name = "جیرنده",
                Slug = "جیرنده",
                ProvinceId = 26
            },
            new()
            {
                Id = 910,
                Name = "چابکسر",
                Slug = "چابکسر",
                ProvinceId = 26
            },
            new()
            {
                Id = 911,
                Name = "چاف و چمخاله",
                Slug = "چاف-و-چمخاله",
                ProvinceId = 26
            },
            new()
            {
                Id = 912,
                Name = "چوبر",
                Slug = "چوبر",
                ProvinceId = 26
            },
            new()
            {
                Id = 913,
                Name = "حویق",
                Slug = "حویق",
                ProvinceId = 26
            },
            new()
            {
                Id = 914,
                Name = "خشکبیجار",
                Slug = "خشکبیجار",
                ProvinceId = 26
            },
            new()
            {
                Id = 915,
                Name = "خمام",
                Slug = "خمام",
                ProvinceId = 26
            },
            new()
            {
                Id = 916,
                Name = "دیلمان",
                Slug = "دیلمان",
                ProvinceId = 26
            },
            new()
            {
                Id = 917,
                Name = "رانکوه",
                Slug = "رانکوه",
                ProvinceId = 26
            },
            new()
            {
                Id = 918,
                Name = "رحیم آباد",
                Slug = "رحیم-آباد",
                ProvinceId = 26
            },
            new()
            {
                Id = 919,
                Name = "رستم آباد",
                Slug = "رستم-آباد",
                ProvinceId = 26
            },
            new()
            {
                Id = 920,
                Name = "رشت",
                Slug = "رشت",
                ProvinceId = 26
            },
            new()
            {
                Id = 921,
                Name = "رضوانشهر",
                Slug = "گیلان-رضوانشهر",
                ProvinceId = 26
            },
            new()
            {
                Id = 922,
                Name = "رودبار",
                Slug = "گیلان-رودبار",
                ProvinceId = 26
            },
            new()
            {
                Id = 923,
                Name = "رودبنه",
                Slug = "رودبنه",
                ProvinceId = 26
            },
            new()
            {
                Id = 924,
                Name = "رودسر",
                Slug = "رودسر",
                ProvinceId = 26
            },
            new()
            {
                Id = 925,
                Name = "سنگر",
                Slug = "سنگر",
                ProvinceId = 26
            },
            new()
            {
                Id = 926,
                Name = "سیاهکل",
                Slug = "سیاهکل",
                ProvinceId = 26
            },
            new()
            {
                Id = 927,
                Name = "شفت",
                Slug = "شفت",
                ProvinceId = 26
            },
            new()
            {
                Id = 928,
                Name = "شلمان",
                Slug = "شلمان",
                ProvinceId = 26
            },
            new()
            {
                Id = 929,
                Name = "صومعه سرا",
                Slug = "صومعه-سرا",
                ProvinceId = 26
            },
            new()
            {
                Id = 930,
                Name = "فومن",
                Slug = "فومن",
                ProvinceId = 26
            },
            new()
            {
                Id = 931,
                Name = "کلاچای",
                Slug = "کلاچای",
                ProvinceId = 26
            },
            new()
            {
                Id = 932,
                Name = "کوچصفهان",
                Slug = "کوچصفهان",
                ProvinceId = 26
            },
            new()
            {
                Id = 933,
                Name = "کومله",
                Slug = "کومله",
                ProvinceId = 26
            },
            new()
            {
                Id = 934,
                Name = "کیاشهر",
                Slug = "کیاشهر",
                ProvinceId = 26
            },
            new()
            {
                Id = 935,
                Name = "گوراب زرمیخ",
                Slug = "گوراب-زرمیخ",
                ProvinceId = 26
            },
            new()
            {
                Id = 936,
                Name = "لاهیجان",
                Slug = "لاهیجان",
                ProvinceId = 26
            },
            new()
            {
                Id = 937,
                Name = "لشت نشا",
                Slug = "لشت-نشا",
                ProvinceId = 26
            },
            new()
            {
                Id = 938,
                Name = "لنگرود",
                Slug = "لنگرود",
                ProvinceId = 26
            },
            new()
            {
                Id = 939,
                Name = "لوشان",
                Slug = "لوشان",
                ProvinceId = 26
            },
            new()
            {
                Id = 940,
                Name = "لولمان",
                Slug = "لولمان",
                ProvinceId = 26
            },
            new()
            {
                Id = 941,
                Name = "لوندویل",
                Slug = "لوندویل",
                ProvinceId = 26
            },
            new()
            {
                Id = 942,
                Name = "لیسار",
                Slug = "لیسار",
                ProvinceId = 26
            },
            new()
            {
                Id = 943,
                Name = "ماسال",
                Slug = "ماسال",
                ProvinceId = 26
            },
            new()
            {
                Id = 944,
                Name = "ماسوله",
                Slug = "ماسوله",
                ProvinceId = 26
            },
            new()
            {
                Id = 945,
                Name = "مرجقل",
                Slug = "مرجقل",
                ProvinceId = 26
            },
            new()
            {
                Id = 946,
                Name = "منجیل",
                Slug = "منجیل",
                ProvinceId = 26
            },
            new()
            {
                Id = 947,
                Name = "واجارگاه",
                Slug = "واجارگاه",
                ProvinceId = 26
            },
            new()
            {
                Id = 948,
                Name = "امیرکلا",
                Slug = "امیرکلا",
                ProvinceId = 27
            },
            new()
            {
                Id = 949,
                Name = "ایزدشهر",
                Slug = "ایزدشهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 950,
                Name = "آلاشت",
                Slug = "آلاشت",
                ProvinceId = 27
            },
            new()
            {
                Id = 951,
                Name = "آمل",
                Slug = "آمل",
                ProvinceId = 27
            },
            new()
            {
                Id = 952,
                Name = "بابل",
                Slug = "بابل",
                ProvinceId = 27
            },
            new()
            {
                Id = 953,
                Name = "بابلسر",
                Slug = "بابلسر",
                ProvinceId = 27
            },
            new()
            {
                Id = 954,
                Name = "بلده",
                Slug = "مازندران-بلده",
                ProvinceId = 27
            },
            new()
            {
                Id = 955,
                Name = "بهشهر",
                Slug = "بهشهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 956,
                Name = "بهنمیر",
                Slug = "بهنمیر",
                ProvinceId = 27
            },
            new()
            {
                Id = 957,
                Name = "پل سفید",
                Slug = "پل-سفید",
                ProvinceId = 27
            },
            new()
            {
                Id = 958,
                Name = "تنکابن",
                Slug = "تنکابن",
                ProvinceId = 27
            },
            new()
            {
                Id = 959,
                Name = "جویبار",
                Slug = "جویبار",
                ProvinceId = 27
            },
            new()
            {
                Id = 960,
                Name = "چالوس",
                Slug = "چالوس",
                ProvinceId = 27
            },
            new()
            {
                Id = 961,
                Name = "چمستان",
                Slug = "چمستان",
                ProvinceId = 27
            },
            new()
            {
                Id = 962,
                Name = "خرم آباد",
                Slug = "مازندران-خرم-آباد",
                ProvinceId = 27
            },
            new()
            {
                Id = 963,
                Name = "خلیل شهر",
                Slug = "خلیل-شهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 964,
                Name = "خوش رودپی",
                Slug = "خوش-رودپی",
                ProvinceId = 27
            },
            new()
            {
                Id = 965,
                Name = "دابودشت",
                Slug = "دابودشت",
                ProvinceId = 27
            },
            new()
            {
                Id = 966,
                Name = "رامسر",
                Slug = "رامسر",
                ProvinceId = 27
            },
            new()
            {
                Id = 967,
                Name = "رستمکلا",
                Slug = "رستمکلا",
                ProvinceId = 27
            },
            new()
            {
                Id = 968,
                Name = "رویان",
                Slug = "رویان",
                ProvinceId = 27
            },
            new()
            {
                Id = 969,
                Name = "رینه",
                Slug = "رینه",
                ProvinceId = 27
            },
            new()
            {
                Id = 970,
                Name = "زرگرمحله",
                Slug = "زرگرمحله",
                ProvinceId = 27
            },
            new()
            {
                Id = 971,
                Name = "زیرآب",
                Slug = "زیرآب",
                ProvinceId = 27
            },
            new()
            {
                Id = 972,
                Name = "ساری",
                Slug = "ساری",
                ProvinceId = 27
            },
            new()
            {
                Id = 973,
                Name = "سرخرود",
                Slug = "سرخرود",
                ProvinceId = 27
            },
            new()
            {
                Id = 974,
                Name = "سلمان شهر",
                Slug = "سلمان-شهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 975,
                Name = "سورک",
                Slug = "سورک",
                ProvinceId = 27
            },
            new()
            {
                Id = 976,
                Name = "شیرگاه",
                Slug = "شیرگاه",
                ProvinceId = 27
            },
            new()
            {
                Id = 977,
                Name = "شیرود",
                Slug = "شیرود",
                ProvinceId = 27
            },
            new()
            {
                Id = 978,
                Name = "عباس آباد",
                Slug = "عباس-آباد",
                ProvinceId = 27
            },
            new()
            {
                Id = 979,
                Name = "فریدونکنار",
                Slug = "فریدونکنار",
                ProvinceId = 27
            },
            new()
            {
                Id = 980,
                Name = "فریم",
                Slug = "فریم",
                ProvinceId = 27
            },
            new()
            {
                Id = 981,
                Name = "قائم شهر",
                Slug = "قائم-شهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 982,
                Name = "کتالم",
                Slug = "کتالم",
                ProvinceId = 27
            },
            new()
            {
                Id = 983,
                Name = "کلارآباد",
                Slug = "کلارآباد",
                ProvinceId = 27
            },
            new()
            {
                Id = 984,
                Name = "کلاردشت",
                Slug = "کلاردشت",
                ProvinceId = 27
            },
            new()
            {
                Id = 985,
                Name = "کله بست",
                Slug = "کله-بست",
                ProvinceId = 27
            },
            new()
            {
                Id = 986,
                Name = "کوهی خیل",
                Slug = "کوهی-خیل",
                ProvinceId = 27
            },
            new()
            {
                Id = 987,
                Name = "کیاسر",
                Slug = "کیاسر",
                ProvinceId = 27
            },
            new()
            {
                Id = 988,
                Name = "کیاکلا",
                Slug = "کیاکلا",
                ProvinceId = 27
            },
            new()
            {
                Id = 989,
                Name = "گتاب",
                Slug = "گتاب",
                ProvinceId = 27
            },
            new()
            {
                Id = 990,
                Name = "گزنک",
                Slug = "گزنک",
                ProvinceId = 27
            },
            new()
            {
                Id = 991,
                Name = "گلوگاه",
                Slug = "گلوگاه",
                ProvinceId = 27
            },
            new()
            {
                Id = 992,
                Name = "محمودآباد",
                Slug = "مازندران-محمودآباد",
                ProvinceId = 27
            },
            new()
            {
                Id = 993,
                Name = "مرزن آباد",
                Slug = "مرزن-آباد",
                ProvinceId = 27
            },
            new()
            {
                Id = 994,
                Name = "مرزیکلا",
                Slug = "مرزیکلا",
                ProvinceId = 27
            },
            new()
            {
                Id = 995,
                Name = "نشتارود",
                Slug = "نشتارود",
                ProvinceId = 27
            },
            new()
            {
                Id = 996,
                Name = "نکا",
                Slug = "نکا",
                ProvinceId = 27
            },
            new()
            {
                Id = 997,
                Name = "نور",
                Slug = "نور",
                ProvinceId = 27
            },
            new()
            {
                Id = 998,
                Name = "نوشهر",
                Slug = "نوشهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 999,
                Name = "اراک",
                Slug = "اراک",
                ProvinceId = 28
            },
            new()
            {
                Id = 1000,
                Name = "آستانه",
                Slug = "آستانه",
                ProvinceId = 28
            },
            new()
            {
                Id = 1001,
                Name = "آشتیان",
                Slug = "آشتیان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1002,
                Name = "پرندک",
                Slug = "پرندک",
                ProvinceId = 28
            },
            new()
            {
                Id = 1003,
                Name = "تفرش",
                Slug = "تفرش",
                ProvinceId = 28
            },
            new()
            {
                Id = 1004,
                Name = "توره",
                Slug = "توره",
                ProvinceId = 28
            },
            new()
            {
                Id = 1005,
                Name = "جاورسیان",
                Slug = "جاورسیان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1006,
                Name = "خشکرود",
                Slug = "خشکرود",
                ProvinceId = 28
            },
            new()
            {
                Id = 1007,
                Name = "خمین",
                Slug = "خمین",
                ProvinceId = 28
            },
            new()
            {
                Id = 1008,
                Name = "خنداب",
                Slug = "خنداب",
                ProvinceId = 28
            },
            new()
            {
                Id = 1009,
                Name = "داودآباد",
                Slug = "داودآباد",
                ProvinceId = 28
            },
            new()
            {
                Id = 1010,
                Name = "دلیجان",
                Slug = "دلیجان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1011,
                Name = "رازقان",
                Slug = "رازقان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1012,
                Name = "زاویه",
                Slug = "زاویه",
                ProvinceId = 28
            },
            new()
            {
                Id = 1013,
                Name = "ساروق",
                Slug = "ساروق",
                ProvinceId = 28
            },
            new()
            {
                Id = 1014,
                Name = "ساوه",
                Slug = "ساوه",
                ProvinceId = 28
            },
            new()
            {
                Id = 1015,
                Name = "سنجان",
                Slug = "سنجان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1016,
                Name = "شازند",
                Slug = "شازند",
                ProvinceId = 28
            },
            new()
            {
                Id = 1017,
                Name = "غرق آباد",
                Slug = "غرق-آباد",
                ProvinceId = 28
            },
            new()
            {
                Id = 1018,
                Name = "فرمهین",
                Slug = "فرمهین",
                ProvinceId = 28
            },
            new()
            {
                Id = 1019,
                Name = "قورچی باشی",
                Slug = "قورچی-باشی",
                ProvinceId = 28
            },
            new()
            {
                Id = 1020,
                Name = "کرهرود",
                Slug = "کرهرود",
                ProvinceId = 28
            },
            new()
            {
                Id = 1021,
                Name = "کمیجان",
                Slug = "کمیجان",
                ProvinceId = 28
            },
            new()
            {
                Id = 1022,
                Name = "مامونیه",
                Slug = "مامونیه",
                ProvinceId = 28
            },
            new()
            {
                Id = 1023,
                Name = "محلات",
                Slug = "محلات",
                ProvinceId = 28
            },
            new()
            {
                Id = 1024,
                Name = "مهاجران",
                Slug = "مهاجران",
                ProvinceId = 28
            },
            new()
            {
                Id = 1025,
                Name = "میلاجرد",
                Slug = "میلاجرد",
                ProvinceId = 28
            },
            new()
            {
                Id = 1026,
                Name = "نراق",
                Slug = "نراق",
                ProvinceId = 28
            },
            new()
            {
                Id = 1027,
                Name = "نوبران",
                Slug = "نوبران",
                ProvinceId = 28
            },
            new()
            {
                Id = 1028,
                Name = "نیمور",
                Slug = "نیمور",
                ProvinceId = 28
            },
            new()
            {
                Id = 1029,
                Name = "هندودر",
                Slug = "هندودر",
                ProvinceId = 28
            },
            new()
            {
                Id = 1030,
                Name = "ابوموسی",
                Slug = "ابوموسی",
                ProvinceId = 29
            },
            new()
            {
                Id = 1031,
                Name = "بستک",
                Slug = "بستک",
                ProvinceId = 29
            },
            new()
            {
                Id = 1032,
                Name = "بندرجاسک",
                Slug = "بندرجاسک",
                ProvinceId = 29
            },
            new()
            {
                Id = 1033,
                Name = "بندرچارک",
                Slug = "بندرچارک",
                ProvinceId = 29
            },
            new()
            {
                Id = 1034,
                Name = "بندرخمیر",
                Slug = "بندرخمیر",
                ProvinceId = 29
            },
            new()
            {
                Id = 1035,
                Name = "بندرعباس",
                Slug = "بندرعباس",
                ProvinceId = 29
            },
            new()
            {
                Id = 1036,
                Name = "بندرلنگه",
                Slug = "بندرلنگه",
                ProvinceId = 29
            },
            new()
            {
                Id = 1037,
                Name = "بیکا",
                Slug = "بیکا",
                ProvinceId = 29
            },
            new()
            {
                Id = 1038,
                Name = "پارسیان",
                Slug = "پارسیان",
                ProvinceId = 29
            },
            new()
            {
                Id = 1039,
                Name = "تخت",
                Slug = "تخت",
                ProvinceId = 29
            },
            new()
            {
                Id = 1040,
                Name = "جناح",
                Slug = "جناح",
                ProvinceId = 29
            },
            new()
            {
                Id = 1041,
                Name = "حاجی آباد",
                Slug = "هرمزگان-حاجی-آباد",
                ProvinceId = 29
            },
            new()
            {
                Id = 1042,
                Name = "درگهان",
                Slug = "درگهان",
                ProvinceId = 29
            },
            new()
            {
                Id = 1043,
                Name = "دهبارز",
                Slug = "دهبارز",
                ProvinceId = 29
            },
            new()
            {
                Id = 1044,
                Name = "رویدر",
                Slug = "رویدر",
                ProvinceId = 29
            },
            new()
            {
                Id = 1045,
                Name = "زیارتعلی",
                Slug = "زیارتعلی",
                ProvinceId = 29
            },
            new()
            {
                Id = 1046,
                Name = "سردشت",
                Slug = "هرمزگان-سردشت",
                ProvinceId = 29
            },
            new()
            {
                Id = 1047,
                Name = "سندرک",
                Slug = "سندرک",
                ProvinceId = 29
            },
            new()
            {
                Id = 1048,
                Name = "سوزا",
                Slug = "سوزا",
                ProvinceId = 29
            },
            new()
            {
                Id = 1049,
                Name = "سیریک",
                Slug = "سیریک",
                ProvinceId = 29
            },
            new()
            {
                Id = 1050,
                Name = "فارغان",
                Slug = "فارغان",
                ProvinceId = 29
            },
            new()
            {
                Id = 1051,
                Name = "فین",
                Slug = "فین",
                ProvinceId = 29
            },
            new()
            {
                Id = 1052,
                Name = "قشم",
                Slug = "قشم",
                ProvinceId = 29
            },
            new()
            {
                Id = 1053,
                Name = "قلعه قاضی",
                Slug = "قلعه-قاضی",
                ProvinceId = 29
            },
            new()
            {
                Id = 1054,
                Name = "کنگ",
                Slug = "کنگ",
                ProvinceId = 29
            },
            new()
            {
                Id = 1055,
                Name = "کوشکنار",
                Slug = "کوشکنار",
                ProvinceId = 29
            },
            new()
            {
                Id = 1056,
                Name = "کیش",
                Slug = "کیش",
                ProvinceId = 29
            },
            new()
            {
                Id = 1057,
                Name = "گوهران",
                Slug = "گوهران",
                ProvinceId = 29
            },
            new()
            {
                Id = 1058,
                Name = "میناب",
                Slug = "میناب",
                ProvinceId = 29
            },
            new()
            {
                Id = 1059,
                Name = "هرمز",
                Slug = "هرمز",
                ProvinceId = 29
            },
            new()
            {
                Id = 1060,
                Name = "هشتبندی",
                Slug = "هشتبندی",
                ProvinceId = 29
            },
            new()
            {
                Id = 1061,
                Name = "ازندریان",
                Slug = "ازندریان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1062,
                Name = "اسدآباد",
                Slug = "اسدآباد",
                ProvinceId = 30
            },
            new()
            {
                Id = 1063,
                Name = "برزول",
                Slug = "برزول",
                ProvinceId = 30
            },
            new()
            {
                Id = 1064,
                Name = "بهار",
                Slug = "بهار",
                ProvinceId = 30
            },
            new()
            {
                Id = 1065,
                Name = "تویسرکان",
                Slug = "تویسرکان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1066,
                Name = "جورقان",
                Slug = "جورقان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1067,
                Name = "جوکار",
                Slug = "جوکار",
                ProvinceId = 30
            },
            new()
            {
                Id = 1068,
                Name = "دمق",
                Slug = "دمق",
                ProvinceId = 30
            },
            new()
            {
                Id = 1069,
                Name = "رزن",
                Slug = "رزن",
                ProvinceId = 30
            },
            new()
            {
                Id = 1070,
                Name = "زنگنه",
                Slug = "زنگنه",
                ProvinceId = 30
            },
            new()
            {
                Id = 1071,
                Name = "سامن",
                Slug = "سامن",
                ProvinceId = 30
            },
            new()
            {
                Id = 1072,
                Name = "سرکان",
                Slug = "سرکان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1073,
                Name = "شیرین سو",
                Slug = "شیرین-سو",
                ProvinceId = 30
            },
            new()
            {
                Id = 1074,
                Name = "صالح آباد",
                Slug = "همدان-صالح-آباد",
                ProvinceId = 30
            },
            new()
            {
                Id = 1075,
                Name = "فامنین",
                Slug = "فامنین",
                ProvinceId = 30
            },
            new()
            {
                Id = 1076,
                Name = "فرسفج",
                Slug = "فرسفج",
                ProvinceId = 30
            },
            new()
            {
                Id = 1077,
                Name = "فیروزان",
                Slug = "فیروزان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1078,
                Name = "قروه درجزین",
                Slug = "قروه-درجزین",
                ProvinceId = 30
            },
            new()
            {
                Id = 1079,
                Name = "قهاوند",
                Slug = "قهاوند",
                ProvinceId = 30
            },
            new()
            {
                Id = 1080,
                Name = "کبودر آهنگ",
                Slug = "کبودر-آهنگ",
                ProvinceId = 30
            },
            new()
            {
                Id = 1081,
                Name = "گل تپه",
                Slug = "گل-تپه",
                ProvinceId = 30
            },
            new()
            {
                Id = 1082,
                Name = "گیان",
                Slug = "گیان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1083,
                Name = "لالجین",
                Slug = "لالجین",
                ProvinceId = 30
            },
            new()
            {
                Id = 1084,
                Name = "مریانج",
                Slug = "مریانج",
                ProvinceId = 30
            },
            new()
            {
                Id = 1085,
                Name = "ملایر",
                Slug = "ملایر",
                ProvinceId = 30
            },
            new()
            {
                Id = 1086,
                Name = "نهاوند",
                Slug = "نهاوند",
                ProvinceId = 30
            },
            new()
            {
                Id = 1087,
                Name = "همدان",
                Slug = "همدان",
                ProvinceId = 30
            },
            new()
            {
                Id = 1088,
                Name = "ابرکوه",
                Slug = "ابرکوه",
                ProvinceId = 31
            },
            new()
            {
                Id = 1089,
                Name = "احمدآباد",
                Slug = "احمدآباد",
                ProvinceId = 31
            },
            new()
            {
                Id = 1090,
                Name = "اردکان",
                Slug = "یزد-اردکان",
                ProvinceId = 31
            },
            new()
            {
                Id = 1091,
                Name = "اشکذر",
                Slug = "اشکذر",
                ProvinceId = 31
            },
            new()
            {
                Id = 1092,
                Name = "بافق",
                Slug = "بافق",
                ProvinceId = 31
            },
            new()
            {
                Id = 1093,
                Name = "بفروئیه",
                Slug = "بفروئیه",
                ProvinceId = 31
            },
            new()
            {
                Id = 1094,
                Name = "بهاباد",
                Slug = "بهاباد",
                ProvinceId = 31
            },
            new()
            {
                Id = 1095,
                Name = "تفت",
                Slug = "تفت",
                ProvinceId = 31
            },
            new()
            {
                Id = 1096,
                Name = "حمیدیا",
                Slug = "حمیدیا",
                ProvinceId = 31
            },
            new()
            {
                Id = 1097,
                Name = "خضرآباد",
                Slug = "خضرآباد",
                ProvinceId = 31
            },
            new()
            {
                Id = 1098,
                Name = "دیهوک",
                Slug = "دیهوک",
                ProvinceId = 31
            },
            new()
            {
                Id = 1099,
                Name = "زارچ",
                Slug = "زارچ",
                ProvinceId = 31
            },
            new()
            {
                Id = 1100,
                Name = "شاهدیه",
                Slug = "شاهدیه",
                ProvinceId = 31
            },
            new()
            {
                Id = 1101,
                Name = "طبس",
                Slug = "یزد-طبس",
                ProvinceId = 31
            },
            new()
            {
                Id = 1103,
                Name = "عقدا",
                Slug = "عقدا",
                ProvinceId = 31
            },
            new()
            {
                Id = 1104,
                Name = "مروست",
                Slug = "مروست",
                ProvinceId = 31
            },
            new()
            {
                Id = 1105,
                Name = "مهردشت",
                Slug = "مهردشت",
                ProvinceId = 31
            },
            new()
            {
                Id = 1106,
                Name = "مهریز",
                Slug = "مهریز",
                ProvinceId = 31
            },
            new()
            {
                Id = 1107,
                Name = "میبد",
                Slug = "میبد",
                ProvinceId = 31
            },
            new()
            {
                Id = 1108,
                Name = "ندوشن",
                Slug = "ندوشن",
                ProvinceId = 31
            },
            new()
            {
                Id = 1109,
                Name = "نیر",
                Slug = "یزد-نیر",
                ProvinceId = 31
            },
            new()
            {
                Id = 1110,
                Name = "هرات",
                Slug = "هرات",
                ProvinceId = 31
            },
            new()
            {
                Id = 1111,
                Name = "یزد",
                Slug = "یزد",
                ProvinceId = 31
            },
            new()
            {
                Id = 1116,
                Name = "پرند",
                Slug = "پرند",
                ProvinceId = 8
            },
            new()
            {
                Id = 1117,
                Name = "فردیس",
                Slug = "فردیس",
                ProvinceId = 5
            },
            new()
            {
                Id = 1118,
                Name = "مارلیک",
                Slug = "مارلیک",
                ProvinceId = 5
            },
            new()
            {
                Id = 1119,
                Name = "سادات شهر",
                Slug = "سادات-شهر",
                ProvinceId = 27
            },
            new()
            {
                Id = 1121,
                Name = "زیباکنار",
                Slug = "زیباکنار",
                ProvinceId = 26
            },
            new()
            {
                Id = 1135,
                Name = "کردان",
                Slug = "کردان",
                ProvinceId = 5
            },
            new()
            {
                Id = 1137,
                Name = "ساوجبلاغ",
                Slug = "ساوجبلاغ",
                ProvinceId = 5
            },
            new()
            {
                Id = 1138,
                Name = "تهران دشت",
                Slug = "تهران-دشت",
                ProvinceId = 5
            },
            new()
            {
                Id = 1150,
                Name = "گلبهار",
                Slug = "",
                ProvinceId = 11
            },
            new()
            {
                Id = 1153,
                Name = "قیامدشت",
                Slug = "قیامدشت",
                ProvinceId = 8
            },
            new()
            {
                Id = 1155,
                Name = "بینالود",
                Slug = "بینالود",
                ProvinceId = 11
            },
            new()
            {
                Id = 1159,
                Name = "پیربازار",
                Slug = "پیربازار",
                ProvinceId = 26
            },
            new()
            {
                Id = 1160,
                Name = "رضوانشهر",
                Slug = "رضوانشهر",
                ProvinceId = 31
            }
        };

        await _pg.Cities.AddRangeAsync(cities);

        #endregion

        await _pg.SaveChangesAsync();
    }
}