using System;

public class Player
{
    public int DefultDamage { get; set; }
    public bool ÄrDubbelDamagePå { get; private set;}
    private float DubbelSkadasDuration;
    private float DubbelSkadasTid;
    public bool SamladePowerUp;
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
            int DamageGjort = player.GörSkada();
            Console.WriteLine($"Player gör{DamageGjort}Skada");
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