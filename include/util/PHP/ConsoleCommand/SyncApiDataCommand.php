<?php

namespace Infoball\util\PHP\ConsoleCommand;

use Infoball\util\PHP\DataUpdater\StandingsDataUpdater;
use Symfony\Component\Console\Attribute\AsCommand;
use Symfony\Component\Console\Command\Command;
use Symfony\Component\Console\Input\InputInterface;
use Symfony\Component\Console\Output\OutputInterface;

#[AsCommand(
    name: 'syncApiData',
    description: 'sync data from api in db',
    hidden: false,
    aliases: ['app:syncApiData']
)]
class SyncApiDataCommand extends Command
{
    protected function execute(InputInterface $input, OutputInterface $output): int
    {

        $standingsDataUpdater = new StandingsDataUpdater();
        $standingsDataUpdater->updateStandingsData();

        $output->writeln([
            '',
            'Command executed!',
            '=================',
        ]);

        return Command::SUCCESS;
    }
}