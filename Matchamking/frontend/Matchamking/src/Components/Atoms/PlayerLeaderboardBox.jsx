import React from 'react'
import styled from 'styled-components'
import StyledBox from './BoxStyle'
import LeaderboardState from './LeaderboardState'

const PlayerBox = styled(StyledBox)`
    display: flex;
    cursor: pointer;
    height: 50px;
    font-size: 16px;
    padding-top: 0.5rem;
    padding-bottom: 0.5rem;
    width: 100%;
`
const Position = styled.div`
    text-align: right;
    width: 10%;
`
const PlayerName = styled.div`
    text-align: left;
    width: 30%;
`
const Winrate = styled.div`
    text-align: right;
    width: 20%;
`
const Played = styled.div`
    text-align: center;
    width: 20%;
`


const PlayerLeaderboardBox = (
    {position, playername, winrate, played, state}
    ) => {
  return (
    <PlayerBox>
        <Position>
            {position}
        </Position>
        <LeaderboardState state={state}></LeaderboardState>
        <PlayerName>
           {playername}
        </PlayerName>
        <Winrate>
            {winrate}
        </Winrate>
        <Played>
            {played}
        </Played>
    </PlayerBox>
  )
}

export default PlayerLeaderboardBox