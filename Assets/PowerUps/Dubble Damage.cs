using System;

public class Player
{
    public int DefaultDamage { get; set; }
    public bool IsDoubleDamageActive { get; private set; }
    private float doubleDamageDuration;
    private float doubleDamageTimeRemaining;

    public Player(int defaultDamage)
    {
        DefaultDamage = defaultDamage;
        IsDoubleDamageActive = false;
        doubleDamageDuration = 20f; //activerad i 20 sek
    }

    public void Update(float deltaTime)
    {
        if (IsDoubleDamageActive)
        {
            doubleDamageTimeRemaining -= deltaTime;
            if (doubleDamageTimeRemaining <= 0)
            {
                DeactivateDoubleDamage();
            }
        }
    }

    public void ActivateDoubleDamage()
    {
        IsDoubleDamageActive = true;
        doubleDamageTimeRemaining = doubleDamageDuration;
    }

    private void DeactivateDoubleDamage()
    {
        IsDoubleDamageActive = false;
    }

    public int DealDamage()
    {
        int damage = DefaultDamage;
        if (IsDoubleDamageActive)
        {
            damage *= 2;
        }
        return damage;
    }

    public void OnCollisionWithPowerUp()
    {
        ActivateDoubleDamage();
    }
}

public class PowerUp
{
    public void Activate(Player player)
    {
        player.OnCollisionWithPowerUp();
    }
}

public class Game
{
    private Player player;
    private PowerUp powerUp;

    public Game()
    {
        player = new Player(20); // Normal skada.
        powerUp = new PowerUp();
    }

    public void Update(float deltaTime)
    {
        player.Update(deltaTime);

        if (CheckIfPowerUpCollected())
        {
            powerUp.Activate(player);
        }
    }

    private bool CheckIfPowerUpCollected()
    {
       
        return false; 
    }

    public void PlayerAttack()
    {
        int damageDealt = player.DealDamage();
        Console.WriteLine($"Player dealt {damageDealt} damage");
    }
}

public class Program
{
    public static void Start()
    {
        Game game = new Game();

        float deltaTime = 0.1f;
        for (int i = 0; i < 60; i++)
        {
            game.Update(deltaTime);
            game.PlayerAttack();
        }
    }
}