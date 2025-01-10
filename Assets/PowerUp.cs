using System;

public class Player
{
    public int DefultDamage { get; set; }
    public bool �rDubbelDamageP� { get; private set;}
    private float DubbelSkadasDuration;
    private float DubbelSkadasTid;
    public bool SamladePowerUp;
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
        private PowerUp powerUp;

        public Game()
        {
            player = new Player(20); //Normal skadan.
            powerUp = new PowerUp();

        }

        public void Update(float deltaTime)
        {
            player.Update(deltaTime);

            if (player.SamladePowerUp)
            {
                powerUp.Activate(player);
            }


        }

        private bool KontroleraOmPowerUpHarSamlat()
        {


            return false;
        }

        public void PlayerAtack()
        {
            int DamageGjort = player.G�rSkada();
            Console.WriteLine($"Player g�r{DamageGjort}Skada");
        }


    }

    public static void Main(string[] args)
    {
        Game game = new Game();

        float deltaTime = 0.1f; 
        for (int i = 0; i < 60; i++) 
        {
            game.Update(deltaTime);
            game.PlayerAtack();
        }
    }
    //check
}