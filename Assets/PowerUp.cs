public class Player
{
    public int DefultDamage { get; set; }
    public bool ÄrDubbelDamagePå { get; private set;}
    private float DubbelSkadasDuration;
    private float DubbelSkadasTid;

    public Player(int DefultDamage)
    {
        DefultDamage = DefultDamage;
        ÄrDubbelDamagePå = false;
        DubbelSkadasDuration = 20f; // 20sec varar power upen 

    }

    public void Update(float deltaTime)
    {
        if (ÄrDubbelDamagePå)
        {
            DubbelSkadasTid -= deltaTime;
            if (DubbelSkadasTid <= 0)
            {
                //InaktiveraDoubleDamage();
            }

        }

    }

    public void ActiveradDubbelSkada()
    {
        ÄrDubbelDamagePå = true;
        DubbelSkadasTid = DubbelSkadasDuration;

    }

    private void OactiveradDubboelSkada()
    {
        ÄrDubbelDamagePå = false;

    }

    public int GörSkada()
    {
        int Damage = DefultDamage;
        if (ÄrDubbelDamagePå)
        {
            Damage *= 2;
        }
        return Damage;

    }
    public class PowerUp
    {
        public void Activate(Player player)
        {
            player.ActiveradDubbelSkada();
        }

    }
    public class Game
    {
        private Player player;
        private PowerUp puwerUp;

        public Game()
        {


        }

    }

}