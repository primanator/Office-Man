using Officeman_1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace OfficeMan_1._1
{
    class Mechanics
    {
        public enum character { stand, jumping, falling, landing, crashing };
        public enum game { bird, birds, pause, intersection, audio, new_highscore, end, frontclouds, smoker, cleaner, post_death_animation, totalscore, main_menu, new_record, leaderboard, change_lb_menu };
        Hashtable CharacterState = new Hashtable();
        Hashtable GameState = new Hashtable();
        char direction;
        
        public Mechanics()
        {
            CharacterState.Add(character.stand, false);
            CharacterState.Add(character.jumping, false);
            CharacterState.Add(character.falling, false);
            CharacterState.Add(character.landing, false);
            CharacterState.Add(character.crashing, false);
            GameState.Add(game.bird, false);
            GameState.Add(game.birds, false);
            GameState.Add(game.pause, false);
            GameState.Add(game.intersection, false);
            GameState.Add(game.end, false);
            GameState.Add(game.frontclouds, true);
            GameState.Add(game.new_highscore, false);
            GameState.Add(game.smoker, true);
            GameState.Add(game.cleaner, true);
            GameState.Add(game.post_death_animation, false);
            GameState.Add(game.totalscore, false);
            GameState.Add(game.main_menu, true);
            GameState.Add(game.new_record, false);
            GameState.Add(game.leaderboard, false);
            GameState.Add(game.audio, true);
            GameState.Add(game.change_lb_menu, false);
            direction = 'r';
        }

        public Mechanics(Mechanics obj)
        {
            this.direction = obj.direction;
            foreach (DictionaryEntry kvp in obj.GameState)
                this.GameState.Add(kvp.Key, kvp.Value);
            foreach (DictionaryEntry kvp in CharacterState)
                this.CharacterState.Add(kvp.Key, kvp.Value);
        }

        public bool this[game state]
        {
            get
            {
                foreach (DictionaryEntry kvp in GameState)
                    if ((game)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { GameState[state] = value; }
        }

        public bool this[character state]
        {
            get
            {
                foreach (DictionaryEntry kvp in CharacterState)
                    if ((character)kvp.Key == state)
                        return (bool)kvp.Value;
                return false;
            }
            set { CharacterState[state] = value; }
        }

        public void PegionFly(ref Rectangle PegionPlace)
        {
            PegionPlace.X -= 21;
            PegionPlace.Y -= 7;
        }

        public void TurnLeft(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.X > 25)
                CharacterPlace.X -= 20;
            if (this[character.falling] & direction == 'r')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'l';
        }

        public void TurnRight(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.X < 390)
                CharacterPlace.X += 20;
            if (this[character.falling] & direction == 'l')
                if (this[character.falling])
                    Sources.RotateCharacterPictures();
            direction = 'r';
        }
        public void TurnUp(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.Y > 30)
                CharacterPlace.Y -= 20;
        }

        public void TurnDown(ref Rectangle CharacterPlace)
        {
            if (CharacterPlace.Y < 400) // 390
                CharacterPlace.Y += 20;
        }
    }
}
