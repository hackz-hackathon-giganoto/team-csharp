using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒTƒuƒ{ƒX‚ªg‚¤’e‚ÌON/OFF‚ğØ‚è‘Ö‚¦‚éƒXƒNƒŠƒvƒg
/// </summary>
public class ShotSubBossBulletControler : MonoBehaviour
{
    [SerializeField] private EnemyBulletRotationShot enemyBulletRotationShotScript;
    [SerializeField] private RandomThrowUpShotEnemyBullet randomThrowUpShotEnemyBulletScript;
    [SerializeField] private ShotEnemyBullet shotEnemyBulletScript;
    [SerializeField] private RandomShotEnemyBullet randomShotEnemyBulletScript;
    [SerializeField] private EnemyStatus enemyStatusScript;
    [SerializeField] private SubBossBasicMove subBossBasicMoveScript;
    [SerializeField] private SubBossFirstMove subBossFirstMoveScript;

    [SerializeField] private bool normalRotationShot;
    [SerializeField] private bool stopFirstRotationShot;
    [SerializeField] private bool randomThrowUpShot;
    [SerializeField] private bool randomShot;
    [SerializeField] private bool normalShot;

    [SerializeField] private float normalRotationShotTriggerHitPointPercent;
    [SerializeField] private float stopFirstRotationShotTriggerHitPointPercent;
    [SerializeField] private float randomThrowUpShotTriggerHitPointPercent;
    [SerializeField] private float randomShotTriggerHitPointPercent;
    [SerializeField] private float normalShotTriggerHitPointPercent;
    [SerializeField] private float subBossBasicMoveTriggerHitPointPercent;
    [SerializeField] private float normalRotationShotFinishHitPointPercent;
    [SerializeField] private float stopFirstRotationShotFinishHitPointPercent;
    [SerializeField] private float randomThrowUpShotFinishHitPointPercent;
    [SerializeField] private float randomShotFinishHitPointPercent;
    [SerializeField] private float normalShotFinishHitPointPercent;
    [SerializeField] private float subBossBasicMoveFinishHitPointPercent;
    [SerializeField] private float subBossFirstMoveFinishHitPointPercent;
    private float enemyMaxHitPoint;
    private float enemyHitPoint;
    private float enemyHitPointPercent;
    private float fixPercent = 100;

    private int normalRotationShotActiveCount = 0;
    private int stopFirstRotationShotActiveCount = 0;
    private int randomThrowUpShotActiveCount = 0;
    private int randomShotActiveCount = 0;
    private int normalShotActiveCount = 0;

    void Start()
    {
        enemyMaxHitPoint = enemyStatusScript.enemyHitPoint;
    }

    void Update()
    {
        enemyHitPoint = enemyStatusScript.enemyHitPoint;
        enemyHitPointPercent = enemyHitPoint / enemyMaxHitPoint * fixPercent;
        NormalRotationShotJudge();
        StopFirstRotationShotJudge();
        RandomThrowUpShotJudge();
        RandomShotJudge();
        NormalShotJudge();
        SubBossBasicMoveJudge();
        SubBossFirstMoveJudge();
    }

    /// <summary>
    /// “G‚Ì‰~ó‚É”­Ë‚³‚ê‚é’e‚ª”­Ë‚³‚ê‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void NormalRotationShotJudge()
    {
        if (normalRotationShot && normalRotationShotActiveCount == 0 && normalRotationShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallEnemyBullet();
        }
        if (normalRotationShotActiveCount == 1 && normalRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopNormalEnemyBulletShot();
        }
    }

    /// <summary>
    /// “G‚Ì‰~ó‚É”­Ë‚³‚ê‚é’e‚ª”­Ë‚³‚ê‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void StopFirstRotationShotJudge()
    {
        if (stopFirstRotationShot && stopFirstRotationShotActiveCount == 0 && stopFirstRotationShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallStopFirstEnemyBullet();
        }
        if (stopFirstRotationShotActiveCount == 1 && stopFirstRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopFirstStopEnemyBulletShot();
        }
    }

    /// <summary>
    /// “G‚Ì’e‚ªã•ûŒü‚É‘Å‚¿ã‚°‚ç‚ê‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void RandomThrowUpShotJudge()
    {
        if (randomThrowUpShot && randomThrowUpShotActiveCount == 0 && randomThrowUpShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.CallRandomThrowUpShot();
        }
        if (randomThrowUpShotActiveCount == 1 && randomThrowUpShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.StopRandomThrowUpEnemyBulletShot();
        }
    }

    /// <summary>
    /// “G‚Ì’e‚ªƒ‰ƒ“ƒ_ƒ€‚É”­Ë‚³‚ê‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void RandomShotJudge()
    {
        if (randomShot && randomShotActiveCount == 0 && randomShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.CallRandomShot();
        }
        if (randomShotActiveCount == 1 && randomShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.StopRandomEnemyBulletShot();
        }
    }

    /// <summary>
    /// “G‚Ì’e‚ªˆê’èŠÔŠu‚Å”­Ë‚³‚ê‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void NormalShotJudge()
    {
        if (normalShot && normalShotActiveCount == 0 && normalShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.CallShot();
        }
        if (normalShotActiveCount == 1 && normalShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.StopNormalEnemyBulletShot();
        }
    }

    /// <summary>
    /// “G‚ÌŠî–{‚Ì“®‚«‚ğ‚·‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void SubBossBasicMoveJudge()
    {
        if(subBossBasicMoveTriggerHitPointPercent >= enemyHitPointPercent)
        {
            subBossBasicMoveScript.CallMoveSubBoss();
        }
        if(subBossBasicMoveFinishHitPointPercent >= enemyHitPointPercent)
        {
            subBossBasicMoveScript.StopSubBoss();
        }
    }

    /// <summary>
    /// “G‚ÌÅ‰‚Ì“®‚«‚ğI‚í‚ç‚¹‚é‚©‚ğ”»’è‚·‚éŠÖ”
    /// </summary>
    void SubBossFirstMoveJudge()
    {
        if(subBossFirstMoveFinishHitPointPercent >= enemyHitPointPercent)
        {
            subBossFirstMoveScript.StopSubBossFirstMove();
        }
    }
}
