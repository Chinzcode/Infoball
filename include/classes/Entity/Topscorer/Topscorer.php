<?php

namespace Infoball\classes\Entity\Topscorer;

require_once $_SERVER['DOCUMENT_ROOT'].'/config/setup.php';

/**
 * Class Topscorer
 *
 * Represents a Topscorer entity with id, playerId, name, firstname, lastname, photo, teamName, teamLogo, goals, penaltyGoals.
 */
class Topscorer
{
    /**
     * @var int The id or position of player depending on goals scored.
     */
    protected int $id;

    /**
     * @var int The id of the player.
     */
    protected int $playerId;

    /**
     * @var string The name of the player.
     */
    protected string $name;

    /**
     * @var string The first name of the player.
     */
    protected string $firstname;

    /**
     * @var string The last name of the player.
     */
    protected string $lastname;

    /**
     * @var string The URL of the player's photo.
     */
    protected string $photo;

    /**
     * @var string The name of the team the player belongs to.
     */
    protected string $teamName;

    /**
     * @var string The URL of the team's logo.
     */
    protected string $teamLogo;

    /**
     * @var int The total number of goals scored by the player.
     */
    protected int $goals;

    /**
     * @var int The total number of penalty goals scored by the player.
     */
    protected int $penaltyGoals;

    /**
     * Constructor.
     *
     * @param int $playerId The id of the player.
     * @param string $name The name of the player.
     * @param string $firstname The first name of the player.
     * @param string $lastname The last name of the player.
     * @param string $photo The URL of the player's photo.
     * @param string $teamName The name of the team the player belongs to.
     * @param string $teamLogo The URL of the team's logo.
     * @param int $goals The total number of goals scored by the player.
     * @param int $penaltyGoals The total number of penalty goals scored by the player.
     */
    public function __construct(
        int $playerId,
        string $name,
        string $firstname,
        string $lastname,
        string $photo,
        string $teamName,
        string $teamLogo,
        int $goals,
        int $penaltyGoals
    ) {
        $this->playerId = $playerId;
        $this->name = $name;
        $this->firstname = $firstname;
        $this->lastname = $lastname;
        $this->photo = $photo;
        $this->teamName = $teamName;
        $this->teamLogo = $teamLogo;
        $this->goals = $goals;
        $this->penaltyGoals = $penaltyGoals;
    }

    /**
     * Get the id or position of player depending on Topscorers scored.
     *
     * @return int The id or position of player depending on Topscorers scored.
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Get the id of the player.
     *
     * @return int The id of the player.
     */
    public function getPlayerId()
    {
        return $this->playerId;
    }

    /**
     * Get the name of the player.
     *
     * @return string The name of the player.
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Get the first name of the player.
     *
     * @return string The first name of the player.
     */
    public function getFirstname()
    {
        return $this->firstname;
    }

    /**
     * Get the last name of the player.
     *
     * @return string The last name of the player.
     */
    public function getLastname()
    {
        return $this->lastname;
    }

    /**
     * Get the photo of the player.
     *
     * @return string The photo of the player.
     */
    public function getPhoto()
    {
        return $this->photo;
    }

    /**
     * Get the team name of the player.
     *
     * @return string The team name of the player.
     */
    public function getTeamName()
    {
        return $this->teamName;
    }

    /**
     * Get the team logo of the player.
     *
     * @return string The team logo of the player.
     */
    public function getTeamLogo()
    {
        return $this->teamLogo;
    }

    /**
     * Get the total goals scored by the player.
     *
     * @return int The total goals scored by the player.
     */
    public function getGoals()
    {
        return $this->goals;
    }

    /**
     * Get the total penalty goals scored by the player.
     *
     * @return int The total penalty goals scored by the player.
     */
    public function getPenaltyGoals()
    {
        return $this->penaltyGoals;
    }
}
