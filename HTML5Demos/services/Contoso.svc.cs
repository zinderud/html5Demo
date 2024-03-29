﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public class Contoso
{
    private static Dictionary<string, string> _content = new Dictionary<string, string>();

    static Contoso()
    {
        _content.Add("local",
            "<h2>Local</h2>" +
            "<h3>Tacoma Man Spends 14 Hours on the 405</h3>" +
            "<h4>Calls it \"the hardest 8 miles I've ever driven.\"</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vestibulum sit amet velit. Quisque dolor mauris, ultricies ut, consectetuer a, malesuada a, nisl. Donec a est. Aliquam dictum, lacus eget vestibulum cursus, nunc quam ullamcorper nunc, ut pulvinar erat magna ut nunc. Duis rhoncus nibh non augue. Aliquam nec sapien at ligula mattis ornare. Cras rutrum, quam eget imperdiet elementum, risus urna dapibus nulla, sed varius lacus orci id tellus. Etiam lacus magna, sollicitudin in, scelerisque a, suscipit at, pede. Vivamus tristique convallis lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aliquam commodo enim ac mauris. Nullam tincidunt, libero eget imperdiet aliquam, lectus lorem suscipit justo, in ornare massa risus ut augue. In sit amet felis id sem venenatis tincidunt. Donec nunc. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur mollis tincidunt libero. Suspendisse ac felis id orci ultricies accumsan. Praesent ornare leo quis massa. Vestibulum enim metus, congue sit amet, venenatis a, auctor in, massa.</p><p>Donec elit enim, aliquam ac, laoreet eu, dignissim eu, elit. Aliquam erat volutpat. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In iaculis venenatis pede. Integer porta. Praesent suscipit turpis vitae eros. Sed posuere, libero vitae varius feugiat, sapien magna feugiat libero, eu feugiat quam pede mattis nibh. Praesent ut ipsum vitae risus tristique congue. Phasellus convallis est consequat sapien. Fusce risus nibh, eleifend in, commodo eu, lobortis quis, nunc. Sed leo nisl, congue imperdiet, fermentum sed, imperdiet et, est. Phasellus pellentesque, diam a auctor ultrices, pede mauris tempor tortor, sed consectetuer tellus magna nec erat. Aliquam eget neque. Quisque pellentesque. Fusce elementum, neque hendrerit ultricies convallis, turpis odio congue libero, eget commodo massa orci nec wisi. Fusce condimentum suscipit tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi odio.</p><p>Suspendisse potenti. Cras vestibulum. Vivamus felis. Fusce quis enim nec pede porttitor feugiat. Curabitur tempor. Curabitur at augue vitae diam adipiscing auctor. Nulla accumsan auctor wisi. Fusce ac massa. Donec arcu est, rutrum vitae, lobortis in, adipiscing non, orci. Proin sit amet leo. Donec volutpat, wisi eget aliquam imperdiet, purus sapien hendrerit tellus, vel pretium lorem justo luctus orci. Suspendisse dapibus magna vel lorem. Phasellus quis est. In hac habitasse platea dictumst. Cras sem urna, volutpat ut, laoreet a, auctor eu, est. Cras in metus. Fusce venenatis dapibus pede. Phasellus non leo ut pede congue vulputate.</p><p>Nulla faucibus. Nulla accumsan ante vitae est ultrices lobortis. Donec mollis felis ut tellus. Suspendisse lobortis libero eget sem. Aliquam sit amet tortor. Vivamus aliquet dolor vel risus. Proin feugiat dictum nisl. Quisque ligula erat, pellentesque a, mollis eu, varius ac, ipsum. Vestibulum turpis nulla, eleifend non, rutrum sed, ultrices nec, ipsum. Praesent vel nisl. Etiam id dui. Integer dui mi, sodales vel, convallis quis, tempus molestie, lorem. Praesent tempor mi sit amet turpis tincidunt suscipit. Maecenas elementum. Pellentesque purus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis pretium ante sed nulla. Maecenas convallis vulputate neque.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("national",
            "<h2>National</h2>" +
            "<h3>Fight Breaks Out at Rally for World Peace</h3>" +
            "<h4>Statement expected from organizer once he's released from ICU</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tincidunt dolor ac purus accumsan a hendrerit risus luctus. Sed nibh ante, rutrum a ornare vitae, dapibus et mauris. Pellentesque rutrum, urna ut sagittis commodo, nunc mi fringilla tortor, et rhoncus massa ligula ullamcorper lorem. In pulvinar, urna vitae egestas porta, metus lacus posuere lorem, ac condimentum justo lacus eget sapien. Nullam ultrices laoreet sem ut elementum. Donec quis magna arcu. In ut risus lorem. Praesent quam augue, suscipit sed tristique at, blandit vel felis. Duis dictum mauris id felis consectetur sollicitudin.</p><p>Pellentesque quam est, lobortis nec auctor at, gravida sed tellus. Mauris euismod tortor in est tincidunt viverra. Suspendisse tristique bibendum consectetur. Curabitur sed malesuada mauris. Mauris consequat ipsum sapien. Proin condimentum eleifend nunc, vitae lacinia est commodo sit amet. Curabitur rutrum, elit vitae egestas vestibulum, lectus turpis suscipit purus, in blandit sapien est a tortor. Nullam sed lacus eu nunc semper placerat. Nulla ut massa id risus malesuada bibendum. Phasellus rutrum enim vitae erat ornare tempor. Sed leo eros, consequat ut ultrices eu, lobortis in justo. Phasellus commodo ipsum quis enim cursus accumsan tempus nisl facilisis. Donec et mi mauris, ac rutrum justo. Duis dolor felis, venenatis ut fringilla nec, volutpat vel leo. Vestibulum pretium, nibh eu ultricies viverra, quam velit sagittis metus, non commodo dolor mauris vitae dolor.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("world",
            "<h2>World</h2>" +
            "<h3>French Government Caught Off Guard by Labor Strike</h3>" +
            "<h4>Official: \"We have labor here?\"</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam varius massa eu metus fermentum porttitor. Morbi quis varius enim. Duis sem nibh, imperdiet vitae ultricies ut, lobortis ut massa. Sed turpis enim, volutpat ac faucibus ut, aliquet a metus. Quisque tempus erat metus, id consequat lectus. Mauris vitae pellentesque massa. Nam eu iaculis enim. Vivamus porttitor vestibulum purus, in imperdiet odio tempus ac. Nulla facilisi. Mauris non arcu arcu. Duis fermentum elementum facilisis. Suspendisse vulputate mattis risus, vel vulputate felis pretium ut. Nam quis sagittis leo. Nulla fermentum sem quis purus elementum a lacinia nisl pellentesque.</p><p>Nulla pretium interdum nibh. Fusce venenatis orci enim. Fusce suscipit urna nisl, nec consectetur lacus. Nullam rutrum purus a mauris pulvinar euismod. Phasellus adipiscing convallis urna molestie fermentum. Phasellus eget augue ut libero cursus suscipit. Aenean vulputate, diam a rhoncus convallis, mauris augue condimentum mauris, pharetra rutrum libero dui sit amet orci. Duis vitae massa ipsum. Integer sollicitudin venenatis neque, eu facilisis est molestie quis. Integer cursus risus eget odio tincidunt non mattis ipsum scelerisque. Nullam sed ante quis sapien interdum dignissim ut sit amet purus. Cras orci nulla, tempus eget molestie vel, posuere et justo. Nulla mauris orci, fringilla quis scelerisque eget, facilisis et neque. Vivamus feugiat mi eu lacus gravida malesuada. Sed eu enim ligula.</p><p>In mattis nisl vel magna lacinia laoreet. Phasellus at orci diam. Mauris dui mi, congue eget cursus et, molestie non lectus. Duis ut sapien urna. Fusce vel scelerisque magna. Cras ultrices venenatis augue, vitae lacinia est pretium quis. Mauris non odio vel metus cursus laoreet. Nullam feugiat est nisi, iaculis varius metus. Maecenas viverra turpis quis diam dapibus dignissim. Pellentesque in urna arcu, nec ultricies nibh. Suspendisse rhoncus luctus dignissim. Pellentesque id dui sed ante tempor commodo at at ante.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("baseball",
            "<h2>Baseball</h2>" +
            "<h3>Major Leaguers Strike Over Pay and Benefits</h3>" +
            "<h4>\"How can anyone make it on $3,420,600 a year?\"</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. In venenatis felis aliquet lorem varius a adipiscing sem convallis. Nullam in urna elit, sed interdum magna. Duis luctus fringilla malesuada. Maecenas tincidunt pretium tortor vel laoreet. Duis convallis dapibus diam, id pellentesque mi malesuada eget. Donec mauris quam, rutrum eu vestibulum ut, aliquet vitae libero. Aliquam id mi risus, in commodo magna. Integer eu sapien nibh. Vestibulum aliquam, tellus at imperdiet lobortis, sem metus faucibus lorem, sit amet sodales ligula nisl nec libero. Phasellus lacus purus, bibendum non tristique ut, interdum sit amet dolor. Fusce dictum eros non massa placerat iaculis. Aenean commodo, odio a tempor vehicula, libero augue placerat purus, eget semper dui enim et mauris.</p><p>Morbi eu mi arcu. Phasellus commodo fringilla nunc sed euismod. Cras fermentum adipiscing neque. Fusce vehicula libero tortor. Duis tempor sodales erat, a rhoncus urna euismod a. Cras enim enim, venenatis quis condimentum ac, auctor sed diam. Nullam semper, lectus vitae semper feugiat, ligula magna tristique mauris, quis varius neque orci eu mi.</p><p>Phasellus ullamcorper magna vitae leo facilisis facilisis gravida purus condimentum. Donec non lorem neque. Pellentesque quam justo, ornare sit amet laoreet ac, faucibus in leo. Nulla mattis, quam in feugiat laoreet, leo odio fermentum ipsum, vitae eleifend turpis tortor id massa. Integer aliquet, metus quis dictum congue, libero odio tempor leo, quis varius risus lacus sit amet enim. Etiam laoreet tortor quis augue tempus eget euismod quam vestibulum. Quisque sollicitudin, erat in posuere faucibus, enim mi ornare elit, eget porta neque purus nec turpis. Phasellus erat magna, ultrices eget dignissim a, feugiat quis ligula. Phasellus ut viverra enim. Vestibulum mattis tortor sed mauris luctus sit amet ullamcorper augue tempus.</p><p>Nunc in arcu eget risus dignissim euismod sed eu ante. Suspendisse lobortis sodales imperdiet. Aenean vel sem tortor, non malesuada felis. Phasellus nunc urna, congue et congue eu, tristique vitae ligula. Quisque mollis felis at sapien molestie a fermentum erat eleifend. Proin feugiat volutpat dui quis condimentum. Mauris et enim id purus pellentesque pellentesque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porttitor pulvinar accumsan. Vivamus lacus nisl, faucibus fringilla commodo ut, venenatis id elit. Donec faucibus neque eu arcu consequat placerat.</p><p>In ut eros tortor. Nullam et nibh eget justo hendrerit sollicitudin a ut elit. Vestibulum luctus tortor vitae metus vulputate sit amet venenatis quam dictum. Vivamus volutpat, ipsum non elementum hendrerit, leo lorem cursus quam, sed scelerisque tellus justo sed lorem. Vestibulum in nibh nibh, nec imperdiet nulla. Donec et magna est. Aliquam hendrerit, turpis ut egestas fermentum, justo neque iaculis nisi, a elementum nunc dolor id metus. Aliquam erat volutpat. Aenean feugiat velit eu magna vulputate aliquet.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("basketball",
            "<h2>Basketball</h2>" +
            "<h3>NBA Announces Sweeping Contract Modifications</h3>" +
            "<h4>Addition of in-house bail bondsmen widely hailed as positive move by players</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent turpis magna, sodales in facilisis ac, ornare egestas enim. Suspendisse vel nulla nulla, quis tincidunt sapien. Aenean sapien erat, rhoncus in volutpat vel, dapibus eget nisl. Donec augue eros, dignissim a euismod a, ultrices ut mi. Duis congue interdum tellus vel pellentesque. Curabitur orci augue, porttitor non vestibulum vitae, dictum sit amet orci. Vestibulum non purus a quam congue iaculis. Nullam pulvinar faucibus scelerisque. Ut pellentesque sollicitudin congue. Integer sit amet elit augue. Etiam pharetra tortor porttitor eros auctor nec rutrum sem mollis.</p><p>Fusce pretium venenatis viverra. Donec fringilla leo ac augue scelerisque dignissim. Donec volutpat risus eget enim vehicula vitae cursus arcu placerat. Phasellus eu ipsum ligula, at convallis sapien. Phasellus a tellus vehicula est scelerisque tristique. Donec facilisis rhoncus sapien, id interdum risus tincidunt sit amet. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam eget diam ipsum.</p><p>Nulla condimentum feugiat sem, ac interdum diam ultrices non. Donec semper viverra mauris, a pharetra felis auctor dapibus. Sed arcu ipsum, bibendum ut viverra in, placerat nec leo. Aenean ac dictum elit. Phasellus ultricies iaculis elit id aliquam. Maecenas congue porttitor leo, sit amet interdum nulla mollis at. Mauris in felis vel nisi pharetra condimentum.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("football",
            "<h2>Football</h2>" +
            "<h3>Detroit Lions Announce Stadium Improvements</h3>" +
            "<h4>Six more exits to be added before next season</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque cursus viverra rutrum. Integer scelerisque tempor posuere. Aliquam gravida vestibulum condimentum. Donec adipiscing ultricies odio, id interdum lacus congue eu. Ut id metus nibh, et pretium elit. Nam sed nisl eu leo aliquam interdum. Quisque commodo sapien vel justo ultricies id elementum urna rutrum. Morbi blandit leo vel lacus tristique tempor. Proin porttitor placerat erat, nec interdum enim porta quis. Curabitur eu neque non ipsum hendrerit pretium. Mauris imperdiet consequat dapibus. Morbi elementum fringilla ante non hendrerit. Integer at nibh dui, vel ullamcorper nisl. Integer viverra feugiat risus, sit amet dapibus mauris tempus eu. Duis id dolor in neque aliquet aliquam id at nunc. Donec congue arcu id orci ullamcorper a congue justo commodo.</p><p>Donec vel egestas lacus. Vivamus enim quam, congue et dignissim non, porta ac mi. Aenean sapien orci, ultricies id commodo vel, elementum ut mauris. Donec dapibus lorem quis metus semper blandit. Suspendisse ac nisi est, eget accumsan urna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fringilla, quam ut elementum eleifend, enim nisl euismod massa, ut porta libero ipsum at odio. Curabitur quis lectus nibh, ut consectetur erat.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("soccer",
            "<h2>Soccer</h2>" +
            "<h3>Arsenal fans celebrate first goal since 2006</h3>" +
            "<h4>\"It's a small step, but it's a step in the right direction\"</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin gravida massa et neque accumsan at sollicitudin nulla volutpat. Aliquam erat volutpat. Maecenas interdum sem ipsum. Maecenas augue massa, bibendum in tempus non, elementum et nisi. Pellentesque ac aliquam purus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Vestibulum tincidunt fermentum sem, vel eleifend ipsum eleifend in. Nunc condimentum metus et ipsum blandit at interdum mauris rutrum.</p><p>Suspendisse potenti. Donec dolor tellus, adipiscing et sodales at, consectetur eget nunc. Sed elit dolor, hendrerit a egestas et, tempor pulvinar orci. Phasellus quis felis vitae nulla imperdiet suscipit. Nam libero tellus, auctor sit amet tincidunt ut, malesuada vel risus. Morbi dui eros, accumsan vel placerat nec, hendrerit eget ligula. Nunc pulvinar, turpis ac pretium luctus, magna felis sodales augue, sit amet tempus purus orci sit amet augue. Vivamus nec aliquam tortor. Praesent placerat, mauris sed commodo pretium, dui magna convallis metus, elementum fermentum purus nibh sagittis dolor. Sed non arcu lorem, id tempus felis. Cras laoreet, enim sit amet placerat congue, lorem risus dictum sem, vel cursus risus nibh non leo. In iaculis elit eget erat venenatis quis viverra lacus rutrum. Praesent ut scelerisque odio.</p><p>Nulla lacus est, accumsan non egestas at, porttitor a magna. Curabitur posuere odio a sem rhoncus tristique. Aliquam consequat elementum commodo. Donec volutpat, massa sit amet dignissim tincidunt, magna magna sodales leo, gravida dapibus turpis arcu sit amet est. Phasellus est justo, varius ac adipiscing vel, pellentesque ac ipsum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris tortor leo, mattis vel vehicula et, fringilla quis ipsum.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("travel",
            "<h2>Travel</h2>" +
            "<h3>Airlines Announce Lowest European Fares Ever</h3>" +
            "<h4>Execs believe public will bite despite lack of on-board lavatories</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vestibulum sit amet velit. Quisque dolor mauris, ultricies ut, consectetuer a, malesuada a, nisl. Donec a est. Aliquam dictum, lacus eget vestibulum cursus, nunc quam ullamcorper nunc, ut pulvinar erat magna ut nunc. Duis rhoncus nibh non augue. Aliquam nec sapien at ligula mattis ornare. Cras rutrum, quam eget imperdiet elementum, risus urna dapibus nulla, sed varius lacus orci id tellus. Etiam lacus magna, sollicitudin in, scelerisque a, suscipit at, pede. Vivamus tristique convallis lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aliquam commodo enim ac mauris. Nullam tincidunt, libero eget imperdiet aliquam, lectus lorem suscipit justo, in ornare massa risus ut augue. In sit amet felis id sem venenatis tincidunt. Donec nunc. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur mollis tincidunt libero. Suspendisse ac felis id orci ultricies accumsan. Praesent ornare leo quis massa. Vestibulum enim metus, congue sit amet, venenatis a, auctor in, massa.</p><p>Donec elit enim, aliquam ac, laoreet eu, dignissim eu, elit. Aliquam erat volutpat. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In iaculis venenatis pede. Integer porta. Praesent suscipit turpis vitae eros. Sed posuere, libero vitae varius feugiat, sapien magna feugiat libero, eu feugiat quam pede mattis nibh. Praesent ut ipsum vitae risus tristique congue. Phasellus convallis est consequat sapien. Fusce risus nibh, eleifend in, commodo eu, lobortis quis, nunc. Sed leo nisl, congue imperdiet, fermentum sed, imperdiet et, est. Phasellus pellentesque, diam a auctor ultrices, pede mauris tempor tortor, sed consectetuer tellus magna nec erat. Aliquam eget neque. Quisque pellentesque. Fusce elementum, neque hendrerit ultricies convallis, turpis odio congue libero, eget commodo massa orci nec wisi. Fusce condimentum suscipit tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi odio.</p><p>Suspendisse potenti. Cras vestibulum. Vivamus felis. Fusce quis enim nec pede porttitor feugiat. Curabitur tempor. Curabitur at augue vitae diam adipiscing auctor. Nulla accumsan auctor wisi. Fusce ac massa. Donec arcu est, rutrum vitae, lobortis in, adipiscing non, orci. Proin sit amet leo. Donec volutpat, wisi eget aliquam imperdiet, purus sapien hendrerit tellus, vel pretium lorem justo luctus orci. Suspendisse dapibus magna vel lorem. Phasellus quis est. In hac habitasse platea dictumst. Cras sem urna, volutpat ut, laoreet a, auctor eu, est. Cras in metus. Fusce venenatis dapibus pede. Phasellus non leo ut pede congue vulputate.</p><p>Nulla faucibus. Nulla accumsan ante vitae est ultrices lobortis. Donec mollis felis ut tellus. Suspendisse lobortis libero eget sem. Aliquam sit amet tortor. Vivamus aliquet dolor vel risus. Proin feugiat dictum nisl. Quisque ligula erat, pellentesque a, mollis eu, varius ac, ipsum. Vestibulum turpis nulla, eleifend non, rutrum sed, ultrices nec, ipsum. Praesent vel nisl. Etiam id dui. Integer dui mi, sodales vel, convallis quis, tempus molestie, lorem. Praesent tempor mi sit amet turpis tincidunt suscipit. Maecenas elementum. Pellentesque purus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis pretium ante sed nulla. Maecenas convallis vulputate neque.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("entertainment",
            "<h2>Entertainment</h2>" +
            "<h3>Keith Richards Admits to Occasional Drug Use</h3>" +
            "<h4>Shocking announcement prompts calls for mandatory drug testing of rock 'n rollers</h4>" +
            "<p></p>" +
            "<p><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. In semper purus et justo commodo venenatis. Aliquam non porta dui. Donec a sem vel ipsum viverra commodo in varius nibh. Sed accumsan pulvinar diam sit amet mattis. Cras bibendum pellentesque tortor sed placerat. Donec in tristique enim. Nam diam turpis, feugiat et vulputate vel, hendrerit vitae neque. In hac habitasse platea dictumst. Fusce bibendum, mauris quis cursus posuere, nulla purus venenatis magna, nec iaculis dui ante id erat.</p><p>Vivamus eget metus et diam iaculis congue. Cras cursus, felis vitae egestas rutrum, purus purus mattis magna, nec varius erat nulla ut orci. Duis non sapien ante. Proin mollis facilisis mi, et ornare libero varius non. Quisque pretium euismod nibh sit amet tempus. Integer dapibus quam vitae libero pellentesque id scelerisque magna malesuada. Nulla a lectus sapien. Nullam laoreet dictum gravida. Integer suscipit consectetur dolor. Etiam nec erat magna, dapibus viverra lorem. Quisque non lacinia nunc.</p>" +
            "<p>&nbsp;</p>"
        );

        _content.Add("technology",
            "<h2>Technology</h2>" +
            "<h3>C++ Developer Gets a Life</h3>" +
            "<h4>\"Cost me two years salary but it was worth every penny\"</h4>" +
            "<p></p>" +
            "<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas enim. Pellentesque libero urna, malesuada sed, interdum eu, porttitor eget, nisl. Donec interdum hendrerit nulla. Cras ac ipsum. Proin dolor. Quisque accumsan, augue quis tristique faucibus, nisl pede laoreet tortor, eget suscipit nibh nisl non lacus. Cras vitae odio non sapien mattis rutrum. Etiam congue. Suspendisse potenti. Curabitur metus justo, sodales a, posuere eu, ultrices eu, mi. Fusce tristique eros ac pede. Nam blandit, nibh at pharetra luctus, mi felis eleifend ipsum, ac egestas sem mauris feugiat purus. In pellentesque, risus et porta sollicitudin, sapien leo vehicula augue, eu placerat nisl lacus vel mi. Duis quis diam vitae lacus convallis rutrum. Curabitur congue, enim nec luctus vestibulum, wisi enim egestas arcu, mattis consectetuer nulla sapien ut wisi. Suspendisse fermentum. Sed wisi est, ullamcorper in, rhoncus a, varius eget, eros. Sed facilisis, lorem in dignissim accumsan, ipsum felis faucibus neque, faucibus rutrum erat leo sit amet magna.</p><p>Donec eu dui. Duis vitae elit. Phasellus bibendum, elit nec lobortis volutpat, mauris nulla feugiat nisl, non dignissim libero felis dapibus mi. Vivamus blandit lacus feugiat risus. Duis malesuada. Vestibulum nec enim et urna convallis viverra. Nunc tempus arcu. Nunc quam sem, cursus sed, ornare eget, tincidunt id, ligula. Proin luctus augue et nisl. Suspendisse magna odio, luctus quis, sodales et, ullamcorper at, ante. Nam mauris nulla, dictum at, pretium eget, venenatis pulvinar, dui. Sed sagittis posuere metus. Sed congue fringilla erat. Nulla sodales velit volutpat purus. Cras rhoncus. Pellentesque diam arcu, accumsan non, molestie et, nonummy at, nibh. Curabitur erat enim, porttitor sed, placerat eu, convallis eu, nunc. Donec ut leo vel neque gravida condimentum. Pellentesque sed orci.</p>" +
            "<p>&nbsp;</p>"
        );
    }

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "{topic}")]
    public Stream GetArticle(string topic)
    {
        topic = topic.ToLower();
        WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
        string result = _content.ContainsKey(topic) ? _content[topic] : String.Empty;
        return new MemoryStream(ASCIIEncoding.UTF8.GetBytes(result));
    }


    //[OperationContract]
    //[WebInvoke(Method = "GET", UriTemplate = "{topic}")]
    //public Stream YAzilariGetir(string topic)
    //{
    //    topic = topic.ToLower();
    //    WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
    //    string sonuc = _content.ContainsKey(topic) ? _content[topic] : string.Empty;

    //    return  new MemoryStream(ASCIIEncoding.UTF8.GetBytes(sonuc));
    //}
}
