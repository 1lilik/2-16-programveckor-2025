public class Player
{
    public int DefultDamage { get; set; }
    public bool �rDubbelDamageP� { get; private set;}
    private float DubbelSkadasDuration;
    private float DubbelSkadasTid;

    public Player(int DefultDamage)
    {
        DefultDamage = DefultDamage;
        �rDubbelDamageP� = false;
        DubbelSkadasDuration = 20f; // 20sec varar power upen 

    }

    public void Update(float deltaTime)
    {
        if (�rDubbelDamageP�)
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
        �rDubbelDamageP� = true;
        DubbelSkadasTid = DubbelSkadasDuration;

    }

    private void OactiveradDubboelSkada()
    {
        �rDubbelDamageP� = false;

    }

    public int G�rSkada()
    {
        int Damage = DefultDamage;
        if (�rDubbelDamageP�)
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