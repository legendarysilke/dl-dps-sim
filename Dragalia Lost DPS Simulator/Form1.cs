using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DragaliaLostDPSSimulator
{
    public partial class Form1 : Form
    {
        // todo: don't hardcode adventurer and dragon stats, read these from a database later
        int adv_hp = 716;
        int wpn_hp = 143;
        int pr1_hp = 177;
        int pr2_hp = 176;
        int drg_hp = 374;

        int aug_adv_hp = 0;
        int aug_wpn_hp = 0;
        int aug_pr1_hp = 0;
        int aug_pr2_hp = 0;
        int aug_drg_hp = 0;

        int ability_hp_wpn = 0;
        int ability_hp_pr1 = 0;
        int ability_hp_pr2 = 0;
        int ability_hp_drg = 0;

        int adv_str = 480;
        int wpn_str = 556;
        int pr1_str = 64;
        int pr2_str = 64;
        int drg_str = 121;

        int aug_adv_str = 0;
        int aug_wpn_str = 0;
        int aug_pr1_str = 0;
        int aug_pr2_str = 0;
        int aug_drg_str = 0;

        int ability_str_adv = 0;
        int ability_str_wpn = 0;
        int ability_str_pr1 = 0;
        int ability_str_pr2 = 10;
        int ability_str_prt_cap = 40;
        int ability_str_drg = 20;

        int displ_hp = 2160;
        int displ_str = 2978;

        int dojo_lv = 31;
        int altar_lv = 35;
        int slime_lv = 15;

        int ability_sd_adv = 0;
        int ability_sd_wpn = 0;
        int ability_sd_pr1 = 30;
        int ability_sd_pr2 = 0;
        int ability_sd_prt_cap = 40;
        int ability_sd_drg = 90;

        int ability_fs_adv = 0;
        int ability_fs_wpn = 0;
        int ability_fs_pr1 = 0;
        int ability_fs_pr2 = 0;
        int ability_fs_prt_cap = 50;
        int ability_fs_drg = 0;

        int base_crt_rate = 2;
        int base_crt_rate_axe = 4;
        int ability_crt_rate_adv = 0;
        int ability_crt_rate_wpn = 0;
        int ability_crt_rate_pr1 = 8;
        int ability_crt_rate_pr2 = 0;
        int ability_crt_rate_prt_cap = 15;
        int ability_crt_rate_drg = 0;

        int base_crt_mod = 70;
        int ability_crt_mod_adv = 0;
        int ability_crt_mod_wpn = 0;
        int ability_crt_mod_pr1 = 0;
        int ability_crt_mod_pr2 = 0;
        int ability_crt_mod_prt_cap = 25;
        int ability_crt_mod_drg = 0;

        int ability_skill_haste_adv = 0;
        int ability_skill_haste_wpn = 0;
        int ability_skill_haste_pr1 = 0;
        int ability_skill_haste_pr2 = 8;
        int ability_skill_haste_prt_cap = 15;
        int ability_skill_haste_drg = 0;

        int ability_punisher_burn_adv = 0;
        int ability_punisher_burn_wpn = 0;
        int ability_punisher_burn_pr1 = 0;
        int ability_punisher_burn_pr2 = 0;
        int ability_punisher_burn_prt_cap = 30;
        int ability_punisher_burn_drg = 0;

        int ability_punisher_sum = 0;

        /*int ability_punisher_broken_adv = 0;
        int ability_punisher_broken_wpn = 0;
        int ability_punisher_broken_pr1 = 0;
        int ability_punisher_broken_pr2 = 0;
        int ability_punisher_broken_prt_cap = 30;
        int ability_punisher_broken_drg = 0;

        int ability_punisher_broken_sum = 0;*/

        int sd_mult = 40; // integer terms of 100 + x%
        int fs_mult = 40; // integer terms of 100 + x%
        int crt_rate = 10; // integer terms of x%
        int crt_mod = 70; // integer terms of 100 + x%
        int skill_haste = 0; // integer terms of 100 + x%

        double fs_odmult = 8.00f;

        int coability_sd = 15;
        int coability_str = 10;
        int coability_skill_haste = 15;
        int coability_crt_rate = 0;

        bool quad_adv = false;

        int sim_count = 1000;

        int team_dps = 12500; // approximatelly 3 eudens without def down

        int same_ele_bonus = 50; // integer terms of 100 + x%

        bool enable_normal_attacks = true;
        bool enable_fs = true;

        bool enable_s1 = true;
        bool enable_s2 = true;
        bool enable_s3 = true;

        int max_permitted_chain_length = 3;

        // sp counters and costs
        int counter_s1 = 0;
        int counter_s2 = 0;
        int counter_s3 = 0;

        int spcost_s1 = 2376;
        int spcost_s2 = 4880;
        int spcost_s3 = 6847;

        // Lookup tables for facility bonuses
        // these numbers need to be multiplied by 2 in calcs
        double[] dojo_mod_hp = { 0,
             3.0,  3.5,  3.5,  4.0,  4.0,
             4.5,  4.5,  5.0,  5.0,  5.5,
             5.5,  6.0,  6.0,  6.5,  6.5,
             8.0,  8.0,  8.5,  8.5,  9.0,
             9.0,  9.5,  9.5, 10.0, 10.0,
            10.5, 10.5, 11.0, 11.0, 11.5,
            14.0, 14.5, 14.5, 15.0, 15.0};

        double[] dojo_mod_str = { 0,
             3.0,  3.0,  3.5,  3.5,  4.0,
             4.0,  4.5,  4.5,  5.0,  5.0,
             5.5,  5.5,  6.0,  6.0,  6.5,
             8.0,  8.5,  8.5,  9.0,  9.0,
             9.5,  9.5, 10.0, 10.0, 10.5,
            10.5, 11.0, 11.0, 11.5, 11.5,
            14.0, 14.0, 14.5, 14.5, 15.0};

        double[] altar_mod_hp = { 0,
             0.5,  1.0,  1.0,  1.5,  1.5,
             2.0,  2.0,  2.5,  2.5,  3.0,
             3.0,  3.5,  3.5,  4.0,  4.0,
             4.5,  4.5,  5.0,  5.0,  5.5,
             5.5,  6.0,  6.0,  6.5,  6.5,
             7.0,  7.0,  7.5,  7.5,  8.0,
             8.0,  8.5,  8.5,  9.0,  9.0};

        double[] altar_mod_str = { 0,
             0.5,  0.5,  1.0,  1.0,  1.5,
             1.5,  2.0,  2.0,  2.5,  2.5,
             3.0,  3.0,  3.5,  3.5,  4.0,
             4.0,  4.5,  4.5,  5.0,  5.0,
             5.5,  5.5,  6.0,  6.0,  6.5,
             6.5,  7.0,  7.0,  7.5,  7.5,
             8.0,  8.0,  8.5,  8.5,  9.0};

        double[] slime_mod_hp = { 0,
             0.5,  1.0,  1.0,  1.5,  1.5,
             2.0,  2.0,  2.5,  2.5,  3.0,
             3.0,  3.5,  3.5,  4.0,  4.0};

        double[] slime_mod_str = { 0,
             0.5,  0.5,  1.0,  1.0,  1.5,
             1.5,  2.0,  2.0,  2.5,  2.5,
             3.0,  3.0,  3.5,  3.5,  4.0};

        // enemy data
        // todo: change based on supplied data
        int battle_length = 180;

        int enemy_hp = 0; // 0 = infinite
        int enemy_od_start = 50000; // 0 = infinite. damage needed to bring an enemy from normal to OD at start, or after break passes
        int enemy_od_hp = 150000; // 0 = infinite. OD damage needed to bring an enemy from OD start to break state

        double enemy_def = 10;

        int enemy_def_debuff_cap = 50;

        double enemy_break_duration = 10;
        double enemy_break_def_mod = 0.6;

        int enemy_res_burn = 0;

        int enemy_current_hp = 0;
        int enemy_current_od_buildup = 0;
        int enemy_current_od_hp = 0;
        int enemy_state = 0; // 0 = normal, 1 = overdrive, 2 = break

        int frames_od = 0; // frames spent in overdrive
        int frames_break = 0; // frames spent in break

        int total_enemy_break_frames = 0; // time in frames for enemy to be in break per break
        int frames_break_remaining = 0; // remaining frames in break

        bool battle_success = false; // did we beat the enemy?

        int frames_taken = 0;

        List<DamageObject> queued_attacks;

        List<BuffObject> enemy_debuffs;
        List<BuffObject> enemy_afflictions;

        List<BuffObject> player_buffs;

        // UI update checks
        int refresh_interval = 250; // in milliseconds

        public struct DpsResult
        {
            public long dmg_normal;
            public long dmg_fs;
            public long dmg_s1;
            public long dmg_s2;
            public long dmg_s3;
            public double dmg_buff; // Precision issues with long here
            public long dmg_dot;
            public long dmg_bleed;
            public long frames;
        }

        public struct DamageObject
        {
            public int dmg;
            public int frames; // frames to tick down. when reach 0, damage is applied and the struct is deleted
            public string tag;
            public string type; // write down types here
        }

        public struct BuffObject
        {
            public int intensity;
            public int frames; // frames to tick down. when reach 0, the struct is deleted
            public string type; // write down types of debuff here (e.g. str up, def down, etc)
        }

        // rng
        Random rand;

        // statistics
        int attacks = 0;
        int attacks_crt = 0;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            CalculateDisplayedStat();
        }

        void CalculateDisplayedStat()
        {
            // todo: check for same element

            // Displayed HP
            double hp_sum = 
                (adv_hp + aug_adv_hp) + 
                Math.Ceiling((wpn_hp + aug_wpn_hp) * (100 + same_ele_bonus) / 100f) + 
                (pr1_hp + aug_pr1_hp) + 
                (pr2_hp + aug_pr2_hp) +
                Math.Ceiling((drg_hp + aug_drg_hp) * (100 + same_ele_bonus) / 100f);

            int ability_hp_sum = ability_hp_wpn + ability_hp_pr1 + ability_hp_pr2 + ability_hp_drg;

            double halidom_hp_sum = dojo_mod_hp[dojo_lv] * 2 + altar_mod_hp[altar_lv] * 2 + slime_mod_hp[slime_lv];

            int hp_from_halidom = (int)Math.Ceiling((adv_hp + aug_adv_hp) * halidom_hp_sum / 100f);

            int hp_from_ability = (int)Math.Ceiling((hp_sum + hp_from_halidom) * ability_hp_sum / 100f);

            displ_hp = (int)Math.Ceiling(hp_sum + hp_from_ability + hp_from_halidom);

            // Displayed STR
            int str_prn_sum = ability_str_pr1 + ability_str_pr2;
            if (str_prn_sum > ability_str_prt_cap)
                str_prn_sum = ability_str_prt_cap;

            double str_sum =
                (adv_str + aug_adv_str) +
                Math.Ceiling((wpn_str + aug_wpn_str) * (100 + same_ele_bonus) / 100f) +
                (pr1_str + aug_pr1_str) +
                (pr2_str + aug_pr2_str) +
                Math.Ceiling((drg_str + aug_drg_str) * (100 + same_ele_bonus) / 100f);

            int ability_str_sum = 
                ability_str_adv + 
                ability_str_wpn + 
                ability_str_drg +
                str_prn_sum;

            double halidom_str_sum = dojo_mod_str[dojo_lv] * 2 + altar_mod_str[altar_lv] * 2 + slime_mod_str[slime_lv];

            int str_from_halidom = (int)Math.Ceiling((adv_str + aug_adv_str) * halidom_str_sum / 100f);

            int str_from_ability = (int)Math.Ceiling((str_sum + str_from_halidom) * ability_str_sum / 100f);

            displ_str = (int)Math.Ceiling(str_sum + str_from_ability + str_from_halidom);

            // Skill Damage Sum
            int sd_prn_sum = ability_sd_pr1 + ability_sd_pr2;
            if (sd_prn_sum > ability_sd_prt_cap)
                sd_prn_sum = ability_sd_prt_cap;

            int sd_sum =
                ability_sd_adv +
                ability_sd_wpn +
                ability_sd_drg +
                sd_prn_sum;

            sd_mult = sd_sum;

            // Force Damage Sum
            int fs_prn_sum = ability_fs_pr1 + ability_fs_pr2;
            if (fs_prn_sum > ability_fs_prt_cap)
                fs_prn_sum = ability_fs_prt_cap;

            int fs_sum =
                ability_fs_adv +
                ability_fs_wpn +
                ability_fs_drg +
                fs_prn_sum;

            fs_mult = fs_sum;

            // Critical Rate Sum
            int crt_rate_prn_sum = ability_crt_rate_pr1 + ability_crt_rate_pr2;
            if (crt_rate_prn_sum > ability_crt_rate_prt_cap)
                crt_rate_prn_sum = ability_crt_rate_prt_cap;

            int crt_rate_sum =
                base_crt_rate +
                ability_crt_rate_adv +
                ability_crt_rate_wpn +
                ability_crt_rate_drg +
                crt_rate_prn_sum +
                coability_crt_rate;

            crt_rate = crt_rate_sum;

            // Critical Damage Sum
            int crt_mod_prn_sum = ability_crt_mod_pr1 + ability_crt_mod_pr2;
            if (crt_mod_prn_sum > ability_crt_mod_prt_cap)
                crt_mod_prn_sum = ability_crt_mod_prt_cap;

            int crt_mod_sum =
                base_crt_mod +
                ability_crt_mod_adv +
                ability_crt_mod_wpn +
                ability_crt_mod_drg +
                crt_mod_prn_sum;

            crt_mod = crt_mod_sum;

            // Skill Haste Sum
            int skill_haste_prn_sum = ability_skill_haste_pr1 + ability_skill_haste_pr2;
            if (skill_haste_prn_sum > ability_skill_haste_prt_cap)
                skill_haste_prn_sum = ability_skill_haste_prt_cap;

            int skill_haste_sum =
                ability_skill_haste_adv +
                ability_skill_haste_wpn +
                ability_skill_haste_drg +
                skill_haste_prn_sum +
                coability_skill_haste;

            skill_haste = skill_haste_sum;

            // Update the labels

            label_disp_hp.Text = displ_hp.ToString();
            label_disp_str.Text = ((int)Math.Ceiling(displ_str * ((100 + coability_str) / 100f))).ToString();
            label_sd_mult.Text = (((100 + sd_mult) / 100f) * ((100 + coability_sd) / 100f)).ToString("N2");
            label_fs_mult.Text = ((100 + fs_mult) / 100f).ToString("N2");
            label_crt_rate.Text = crt_rate.ToString() + "%";
            label_crt_mod.Text = ((100 + crt_mod) / 100f).ToString("N2");
            label_skill_haste.Text = skill_haste + "%";

            if (enemy_hp == 0)
            {
                label_enemy_hp.Text = "Infinite";
            }
            else
            {
                label_enemy_hp.Text = enemy_hp.ToString();
            }
            label_enemy_od_start.Text = enemy_od_start.ToString();
            label_enemy_od_hp.Text = enemy_od_hp.ToString();
            label_enemy_break_duration.Text = enemy_break_duration.ToString() + " seconds";
            label_enemy_defense_mod.Text = enemy_break_def_mod.ToString();
            label_max_time.Text = battle_length.ToString() + " seconds";
        }

        private void trackBar_dojo_Scroll(object sender, EventArgs e)
        {
            dojo_lv = trackBar_dojo.Value;
            label_dojo_lv.Text = dojo_lv.ToString();

            CalculateDisplayedStat();
        }

        private void trackBar_altar_Scroll(object sender, EventArgs e)
        {
            altar_lv = trackBar_altar.Value;
            label_altar_lv.Text = altar_lv.ToString();

            CalculateDisplayedStat();
        }

        private void trackBar_slime_Scroll(object sender, EventArgs e)
        {
            slime_lv = trackBar_slime.Value;
            label_slime_lv.Text = slime_lv.ToString();

            CalculateDisplayedStat();
        }

        private void comboBox_dragon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // todo; move these data to a different part to keep this clean
            // instead of a switch, might call an external function
            switch (comboBox_dragon.Text)
            {
                case "Cerberus/Agni":
                    drg_hp = 369;
                    drg_str = 127;
                    ability_hp_drg = 0;
                    ability_str_drg = 60;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Konohana Sakuya":
                    drg_hp = 374;
                    drg_str = 121;
                    ability_hp_drg = 0;
                    ability_str_drg = 20;

                    ability_sd_drg = 90;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Arctos":
                    drg_hp = 374;
                    drg_str = 121;
                    ability_hp_drg = 0;
                    ability_str_drg = 45;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 55;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Apollo":
                    drg_hp = 369;
                    drg_str = 127;
                    ability_hp_drg = 0;
                    ability_str_drg = 50;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 20;
                    break;
                case "Prometheus":
                    drg_hp = 374;
                    drg_str = 121;
                    ability_hp_drg = 0;
                    ability_str_drg = 50;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Ifrit":
                    drg_hp = 295;
                    drg_str = 101;
                    ability_hp_drg = 0;
                    ability_str_drg = 45;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "High Brunhilda":
                    drg_hp = 350;
                    drg_str = 120;
                    ability_hp_drg = 30;
                    ability_str_drg = 30;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Pele/Erasmus":
                    drg_hp = 221;
                    drg_str = 76;
                    ability_hp_drg = 0;
                    ability_str_drg = 30;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Brunhilda":
                    drg_hp = 203;
                    drg_str = 70;
                    ability_hp_drg = 0;
                    ability_str_drg = 20;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Homura":
                    drg_hp = 184;
                    drg_str = 63;
                    ability_hp_drg = 0;
                    ability_str_drg = 15;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                case "Kindling Imp":
                    drg_hp = 187;
                    drg_str = 60;
                    ability_hp_drg = 8;
                    ability_str_drg = 8;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
                default:
                    drg_hp = 0;
                    drg_str = 0;
                    ability_hp_drg = 0;
                    ability_str_drg = 0;

                    ability_sd_drg = 0;
                    ability_crt_rate_drg = 0;
                    ability_crt_mod_drg = 0;
                    ability_punisher_burn_drg = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void button_simulate_Click(object sender, EventArgs e)
        {
            // try to parallelize this to improve performance, sim is slow
            Simulate();
        }

        void Simulate()
        {
            SetInteractability(false);

            label_sim_state.Text = "Initializing";

            attacks = 0;
            attacks_crt = 0;

            // todo; move these data to a different part to keep this clean
            int[] frm_cx = { 9, 26, 23, 36, 37 }; // c1 c2 c3 c4 c5 
            int[] frm_cx_c5 = { 9, 26, 23, 36, 34 }; // c1 c2 c3 c4 c5 for c5 + fs ONLY

            int frm_c_endlag = 42; // if c5 ONLY

            int fs_hit = 19;
            int fs_hit_c5 = 44; // if c5 + fs ONLY

            int fs_end = 21;
            int fs_end_c5 = 26; // if c5 + fs ONLY

            int[] damage_cx = { 75, 80, 95, 100, 300 }; // actually 300 is 150 + 150.
            int damage_fs = 115;
            //int damage_ds = 95;

            int[] sp_cx = { 150, 150, 196, 265, 391 };
            int sp_fs = 345;
            //int sp_ds = 143;

            int frm_s1 = 112;
            int frm_s2 = 161;
            int frm_s3 = 182;

            // need to make these more elegant
            int[] damage_s1 = { 375, 375 };
            int[] damage_s2 = { 638 };
            int[] damage_s3 = { 165, 165, 165, 165, 165 };

            // todo: something more elegant
            string tags_s1 = "";
            string tags_s2 = "DefDown 5 10 90";
            string tags_s3 = "";

            // setup
            int frames_to_simulate = battle_length * 60;

            double team_dps_per_frame = team_dps / 60f;

            int damage_floor = 1; // minimum damage on successful hit

            int res_scale_dot = 5;
            int res_scale_blind = 10;
            int res_scale_disabling = 20;

            /*int combo = 0;
            int combo_decay = 0;
            int combo_leniency = 120; // frames before combo is lost*/

            // result variables, damage buckets
            List<DpsResult> list_dps = new List<DpsResult>();
            List<DpsResult> list_dps_odbar = new List<DpsResult>();
            List<DpsResult> list_dps_break = new List<DpsResult>();

            DateTime dt = DateTime.Now;

            for (int s = 0; s < sim_count; s++)
            {
                TimeSpan interval = DateTime.Now - dt;

                if (s == 0 || interval.TotalMilliseconds > refresh_interval)
                {
                    label_sim_state.Text = "Simulating " + (s + 1).ToString();
                    progressBar_sim.Value = (int)Math.Round((s + 1) * 100 / (double)sim_count);
                    Refresh();

                    dt = DateTime.Now;
                }

                DpsResult result = new DpsResult();

                // initialize
                result.dmg_normal = 0;
                result.dmg_fs = 0;
                result.dmg_s1 = 0;
                result.dmg_s2 = 0;
                result.dmg_s3 = 0;
                result.dmg_buff = 0;
                result.dmg_dot = 0;
                result.dmg_bleed = 0;

                DpsResult result_od = new DpsResult();
                result_od.dmg_normal = 0;
                result_od.dmg_fs = 0;
                result_od.dmg_s1 = 0;
                result_od.dmg_s2 = 0;
                result_od.dmg_s3 = 0;
                result_od.dmg_buff = 0;
                result_od.dmg_dot = 0;
                result_od.dmg_bleed = 0;

                DpsResult result_break = new DpsResult();
                result_break.dmg_normal = 0;
                result_break.dmg_fs = 0;
                result_break.dmg_s1 = 0;
                result_break.dmg_s2 = 0;
                result_break.dmg_s3 = 0;
                result_break.dmg_buff = 0;
                result_break.dmg_dot = 0;
                result_break.dmg_bleed = 0;

                bool queue_fs = false;

                enemy_current_hp = enemy_hp;
                enemy_current_od_buildup = enemy_od_start;
                enemy_current_od_hp = enemy_od_hp;

                // player variables
                int str_buff = 0;
                int str_buff_team = 0;
                int enemy_def_debuff = 0;

                // state variables
                int attack_combo = 0; // corresponds to c1-c5, 0 meaning not attacking at the moment.
                int delay = 0;

                frames_od = 0;
                frames_break = 0;
                enemy_state = 0;

                total_enemy_break_frames = (int)(enemy_break_duration * 60);

                battle_success = false;
                frames_taken = 0;

                // holds all queued attacks
                queued_attacks = new List<DamageObject>();

                // holds all debuffs
                enemy_debuffs = new List<BuffObject>();

                for (int i = 0; i <= frames_to_simulate; i++) // <= is to check if we beat the enemy at the final frame
                {
                    // check if we beat the enemy
                    if (battle_success)
                    {
                        frames_taken = i - 1; // give frame count where win registered
                        break; // we're done
                    }
                    else if (i == frames_to_simulate)
                    {
                        frames_taken = i - 1; // it's the same thing?
                        break; // failed quest
                    }
                    // initial housekeeping (always runs)
                    if (enemy_state == 1)
                    {
                        frames_od++;
                    }
                    else if (enemy_state == 2)
                    {
                        frames_break++;
                        frames_break_remaining--;

                        if (frames_break_remaining <= 0)
                        {
                            enemy_state = 0;
                            enemy_current_od_buildup = enemy_od_start;
                            enemy_current_od_hp = enemy_od_hp;
                        }
                    }

                    // Process all debuff objects here
                    if (enemy_debuffs.Count() > 0)
                    {
                        // go thru every object to process debuff timers
                        for (int d = 0; d < enemy_debuffs.Count(); d++)
                        {
                            BuffObject debuff_obj = enemy_debuffs[d];

                            debuff_obj.frames -= 1;

                            enemy_debuffs[d] = debuff_obj;
                        }

                        for (int r = 0; r < enemy_debuffs.Count(); r++)
                        {
                            BuffObject debuff_obj = enemy_debuffs[r];

                            if (debuff_obj.frames <= 0)
                            {
                                enemy_debuffs.RemoveAt(r);
                                r--;
                            }
                        }
                    }

                    // Process team dps
                    if (team_dps > 0)
                    {
                        // calculate def down as a sum of all existing def downs
                        enemy_def_debuff = GetSumOfEnemyDebuffs("DefDown");

                        if (enemy_def_debuff > 0)
                        {
                            double team_dps_tick = team_dps_per_frame;

                            double enemy_def_percent = GetModifiedDefense(enemy_def_debuff) / enemy_def;

                            team_dps_tick = team_dps_tick / enemy_def_percent;

                            double difference = team_dps_tick - team_dps_per_frame;

                            result.dmg_buff += difference;
                            if (enemy_state == 1)
                            {
                                result_od.dmg_buff += difference;
                            }
                            else if (enemy_state == 2)
                            {
                                result_break.dmg_buff += difference / enemy_break_def_mod;
                            }
                        }
                    }

                    // Process all damage objects here
                    if (queued_attacks.Count() > 0)
                    {
                        // go thru every object to process attacks
                        for (int q = 0; q < queued_attacks.Count(); q++)
                        {
                            DamageObject dmg_obj = queued_attacks[q];

                            dmg_obj.frames -= 1;

                            if (dmg_obj.frames <= 0)
                            {
                                // calculate def down as a sum of all existing def downs
                                enemy_def_debuff = GetSumOfEnemyDebuffs("DefDown");

                                switch (dmg_obj.type)
                                {
                                    case "c":
                                        int c = Damage(dmg_obj.dmg, str_buff, enemy_def_debuff, false, false);

                                        result.dmg_normal += c;
                                        if (enemy_state == 1)
                                        {
                                            result_od.dmg_normal += c;
                                        }
                                        else if (enemy_state == 2)
                                        {
                                            result_break.dmg_normal += c;
                                        }
                                        break;
                                    case "fs":
                                        int fs = Damage(dmg_obj.dmg, str_buff, enemy_def_debuff, false, true);

                                        result.dmg_fs += fs;
                                        if (enemy_state == 1)
                                        {
                                            result_od.dmg_fs += (int)Math.Floor(fs * fs_odmult);
                                        }
                                        else if (enemy_state == 2)
                                        {
                                            result_break.dmg_fs += fs;
                                        }
                                        break;
                                    case "s1":
                                        int s1 = Damage(dmg_obj.dmg, str_buff, enemy_def_debuff, true, false);

                                        result.dmg_s1 += s1;
                                        if (enemy_state == 1)
                                        {
                                            result_od.dmg_s1 += s1;
                                        }
                                        else if (enemy_state == 2)
                                        {
                                            result_break.dmg_s1 += s1;
                                        }
                                        break;
                                    case "s2":
                                        int s2 = Damage(dmg_obj.dmg, str_buff, enemy_def_debuff, true, false);

                                        result.dmg_s2 += s2;
                                        if (enemy_state == 1)
                                        {
                                            result_od.dmg_s2 += s2;
                                        }
                                        else if (enemy_state == 2)
                                        {
                                            result_break.dmg_s2 += s2;
                                        }
                                        break;
                                    case "s3":
                                        int s3 = Damage(dmg_obj.dmg, str_buff, enemy_def_debuff, true, false);

                                        result.dmg_s3 += s3;
                                        if (enemy_state == 1)
                                        {
                                            result_od.dmg_s3 += s3;
                                        }
                                        else if (enemy_state == 2)
                                        {
                                            result_break.dmg_s3 += s3;
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                if (dmg_obj.tag != "")
                                {
                                    ApplyDebuff(dmg_obj.tag);
                                }
                            }

                            queued_attacks[q] = dmg_obj;
                        }

                        // go thru every object to remove attacks that have procced
                        for (int r = 0; r < queued_attacks.Count(); r++)
                        {
                            DamageObject dmg_obj = queued_attacks[r];
                            if (dmg_obj.frames <= 0)
                            {
                                queued_attacks.RemoveAt(r);
                                r--;
                            }
                        }
                    }

                    // frame lag prevents input for current frame if delay is not 0
                    if (delay > 0)
                    {
                        delay--;
                        continue;
                    }

                    // i is frame
                    if (delay <= 0)
                    {
                        // idle state
                        // check if skills are ready
                        // todo; non-sequential skill
                        bool used_skill = false;

                        if (counter_s1 >= spcost_s1 && enable_s1)
                        {
                            delay += UseSkill(frm_s1, damage_s1, tags_s1, 1);

                            counter_s1 = 0;
                            used_skill = true;
                        }
                        else if (counter_s2 >= spcost_s2 && enable_s2)
                        {
                            delay += UseSkill(frm_s2, damage_s2, tags_s2, 2);

                            counter_s2 = 0;
                            used_skill = true;
                        }
                        else if(counter_s3 >= spcost_s3 && enable_s3)
                        {
                            delay += UseSkill(frm_s3, damage_s3, tags_s3, 3);

                            counter_s3 = 0;
                            used_skill = true;
                        }

                        if (used_skill)
                        {
                            attack_combo = 0;
                            queue_fs = false;
                            continue; // restart cycle
                        }

                        // check if unit is suppose to fs
                        if (!enable_normal_attacks)
                        {
                            // normal attacks disabled, immediately queue FS
                            queue_fs = true;
                        }
                        if (queue_fs)
                        {
                            int fs_hit_frames = fs_hit;
                            if (attack_combo == 5)
                            {
                                delay = fs_hit_c5 + fs_end_c5;
                                fs_hit_frames = fs_hit_c5;
                            }
                            else
                            {
                                delay = fs_hit + fs_end;
                            }

                            DamageObject dmg_obj_fs = new DamageObject();

                            dmg_obj_fs.dmg = damage_fs;
                            dmg_obj_fs.frames = fs_hit_frames;
                            dmg_obj_fs.type = "fs";
                            dmg_obj_fs.tag = ""; // read this eventually for albert/nefaria/hawk/sazanka/yachiyo/delphi

                            queued_attacks.Add(dmg_obj_fs);
                            // old code for reference
                            /*int f = Damage(damage_fs, str_buff, enemy_def_debuff, false, true);
                            result.dmg_fs += f;
                            if (enemy_state == 1)
                            {
                                result_od.dmg_fs += (int)Math.Floor(f * fs_odmult);
                            }*/

                            // apply fs sp gain
                            GainSP(sp_fs);

                            attack_combo = 0;
                            queue_fs = false;

                            // restart cycle
                            continue;
                        }

                        // get frame data
                        if (attack_combo == 4 && enable_fs) // c5 + fs special case for swords, may use a different method for other weapons
                        {
                            delay = frm_cx_c5[attack_combo]; // alt delay for c5 + fs
                        }
                        else
                        {
                            delay = frm_cx[attack_combo];
                        }

                        // no fs in queue, do a normal attack
                        //result.dmg_normal += damage_cx[attack_combo];
                        // 0, 1, 2, 3, 4 = c1, c2, c3, c4, c5

                        DamageObject dmg_obj_c = new DamageObject();

                        dmg_obj_c.dmg = damage_cx[attack_combo];
                        dmg_obj_c.frames = delay;
                        dmg_obj_c.type = "c";
                        dmg_obj_c.tag = "";

                        queued_attacks.Add(dmg_obj_c);

                        // old code for reference
                        /*int d = Damage(damage_cx[attack_combo], str_buff, enemy_def_debuff, false, false);
                        result.dmg_normal += d;
                        if (enemy_state == 1)
                        {
                            result_od.dmg_normal += d;
                        }*/

                        // also apply sp gain to counters
                        GainSP(sp_cx[attack_combo]);

                        // if cx where x is combo before fs is met, prep for fs on next active frame
                        if ((attack_combo == (max_permitted_chain_length - 1)) && enable_fs) // change this number to adjust for when to fs
                        {
                            queue_fs = true;
                        }
                        // if fs is disabled, simulate intentional delay if not c5, and restart cycle
                        else if ((attack_combo == (max_permitted_chain_length - 1)) && attack_combo != 4 && !enable_fs) // change this number to adjust for when to stop attacking momentarily
                        {
                            delay += 60; // todo: get actual min delay
                            attack_combo = 0;
                            continue;
                        }

                        // if not doing fs, simulate end lag of c5
                        if (attack_combo == 4 && !queue_fs) // end of combo
                        {
                            delay += frm_c_endlag;
                        }

                        attack_combo++;

                        if (attack_combo > 4 && !queue_fs) // if combo at c5 and not fsing, reset it to restart cycle.
                        {
                            // fs check at start needs to read attack combo to determine what frame data to use
                            attack_combo = 0;
                        }
                    }
                }

                // add frame data before submitting and resetting them
                result.frames = frames_taken;
                result_od.frames = frames_od;
                result_break.frames = frames_break;

                list_dps.Add(result);
                list_dps_odbar.Add(result_od);
                list_dps_break.Add(result_break);
            }

            long total_frames = 0;
            foreach (var res in list_dps)
            {
                total_frames += res.frames;
            }
            double length_factor = 60 / (total_frames/(double)list_dps.Count());

            // test
            //battle_success = true; // always display real time

            // commented for reference
            /*double length_factor = 60 / (double)frames_to_simulate;
            if (battle_success)
            {
                length_factor = 60 / (double)frames_taken;
            }*/

            double length_factor_od = 1;

            long total_frames_od = 0;
            foreach (var res in list_dps_odbar)
            {
                total_frames_od += res.frames;
            }
            if (total_frames_od < 1)
            {
                length_factor_od = -1;
            }
            else
            {
                length_factor_od = 60 / (total_frames_od / (double)list_dps_odbar.Count());
            }

            double length_factor_break = 1;
            
            long total_frames_break = 0;
            foreach (var res in list_dps_break)
            {
                total_frames_break += res.frames;
            }
            if (total_frames_break < 1)
            {
                // break never started
                length_factor_break = -1;
            }
            else
            {
                length_factor_break = 60 / (total_frames_break / (double)list_dps_break.Count());
            }
                

            long dps_sum = 0;
            long odps_sum = 0;
            long dps_break_sum = 0;

            long breakdown_dps_normal = 0;
            long breakdown_dps_fs = 0;
            long breakdown_dps_s1 = 0;
            long breakdown_dps_s2 = 0;
            long breakdown_dps_s3 = 0;
            long breakdown_dps_buff = 0;

            long breakdown_dps_odbar_normal = 0;
            long breakdown_dps_odbar_fs = 0;
            long breakdown_dps_odbar_s1 = 0;
            long breakdown_dps_odbar_s2 = 0;
            long breakdown_dps_odbar_s3 = 0;
            long breakdown_dps_odbar_buff = 0;

            long breakdown_dps_break_normal = 0;
            long breakdown_dps_break_fs = 0;
            long breakdown_dps_break_s1 = 0;
            long breakdown_dps_break_s2 = 0;
            long breakdown_dps_break_s3 = 0;
            long breakdown_dps_break_buff = 0;

            long dps_lowest = 0;
            long dps_highest = 0;

            // calculate total damage
            foreach (DpsResult s in list_dps)
            {
                dps_sum += 
                    s.dmg_normal +
                    s.dmg_fs +
                    s.dmg_s1 +
                    s.dmg_s2 +
                    s.dmg_s3 +
                    (long)s.dmg_buff +
                    s.dmg_dot +
                    s.dmg_bleed;

                breakdown_dps_normal += (long)(s.dmg_normal * length_factor);
                breakdown_dps_fs += (long)(s.dmg_fs * length_factor);
                breakdown_dps_s1 += (long)(s.dmg_s1 * length_factor);
                breakdown_dps_s2 += (long)(s.dmg_s2 * length_factor);
                breakdown_dps_s3 += (long)(s.dmg_s3 * length_factor);
                breakdown_dps_buff += (long)(s.dmg_buff * length_factor);

                long current_sum =
                    s.dmg_normal +
                    s.dmg_fs +
                    s.dmg_s1 +
                    s.dmg_s2 +
                    s.dmg_s3 +
                    (long)s.dmg_buff +
                    s.dmg_dot +
                    s.dmg_bleed;

                current_sum = (long)(current_sum * 60 / (double)s.frames);

                if (dps_lowest > current_sum || dps_lowest == 0)
                {
                    dps_lowest = current_sum;
                }

                if (dps_highest < current_sum || dps_highest == 0)
                {
                    dps_highest = current_sum;
                }
            }

            if (length_factor_od > 0)
            {
                foreach (DpsResult s in list_dps_odbar)
                {
                    odps_sum +=
                        s.dmg_normal +
                        s.dmg_fs +
                        s.dmg_s1 +
                        s.dmg_s2 +
                        s.dmg_s3 +
                        (long)s.dmg_buff +
                        s.dmg_dot +
                        s.dmg_bleed;

                    breakdown_dps_odbar_normal += (long)(s.dmg_normal * length_factor_od);
                    breakdown_dps_odbar_fs += (long)(s.dmg_fs * length_factor_od);
                    breakdown_dps_odbar_s1 += (long)(s.dmg_s1 * length_factor_od);
                    breakdown_dps_odbar_s2 += (long)(s.dmg_s2 * length_factor_od);
                    breakdown_dps_odbar_s3 += (long)(s.dmg_s3 * length_factor_od);
                    breakdown_dps_odbar_buff += (long)(s.dmg_buff * length_factor_od);
                }
            }

            if (length_factor_break > 0)
            {
                foreach (DpsResult s in list_dps_break)
                {
                    dps_break_sum +=
                        s.dmg_normal +
                        s.dmg_fs +
                        s.dmg_s1 +
                        s.dmg_s2 +
                        s.dmg_s3 +
                        (long)s.dmg_buff +
                        s.dmg_dot +
                        s.dmg_bleed;

                    breakdown_dps_break_normal += (long)(s.dmg_normal * length_factor_break);
                    breakdown_dps_break_fs += (long)(s.dmg_fs * length_factor_break);
                    breakdown_dps_break_s1 += (long)(s.dmg_s1 * length_factor_break);
                    breakdown_dps_break_s2 += (long)(s.dmg_s2 * length_factor_break);
                    breakdown_dps_break_s3 += (long)(s.dmg_s3 * length_factor_break);
                    breakdown_dps_break_buff += (long)(s.dmg_buff * length_factor_break);
                }
            }

            label_total_dmg.Text = (dps_sum / list_dps.Count()).ToString();
            label_dps.Text = ((int)(dps_sum * length_factor) / list_dps.Count()).ToString();
            label_odps.Text = ((int)(odps_sum * length_factor_od) / list_dps_odbar.Count()).ToString();
            label_dps_break.Text = ((int)(dps_break_sum * length_factor_break / list_dps_break.Count())).ToString();

            label_dps_normal.Text = (breakdown_dps_normal / list_dps.Count()).ToString();
            label_dps_fs.Text = (breakdown_dps_fs / list_dps.Count()).ToString();
            label_dps_s1.Text = (breakdown_dps_s1 / list_dps.Count()).ToString();
            label_dps_s2.Text = (breakdown_dps_s2 / list_dps.Count()).ToString();
            label_dps_s3.Text = (breakdown_dps_s3 / list_dps.Count()).ToString();
            label_dps_buff.Text = (breakdown_dps_buff / list_dps.Count()).ToString();

            label_dps_odbar_normal.Text = (breakdown_dps_odbar_normal / list_dps_odbar.Count()).ToString();
            label_dps_odbar_fs.Text = (breakdown_dps_odbar_fs / list_dps_odbar.Count()).ToString();
            label_dps_odbar_s1.Text = (breakdown_dps_odbar_s1 / list_dps_odbar.Count()).ToString();
            label_dps_odbar_s2.Text = (breakdown_dps_odbar_s2 / list_dps_odbar.Count()).ToString();
            label_dps_odbar_s3.Text = (breakdown_dps_odbar_s3 / list_dps_odbar.Count()).ToString();
            label_dps_odbar_buff.Text = (breakdown_dps_odbar_buff / list_dps_odbar.Count()).ToString();

            label_dps_break_normal.Text = (breakdown_dps_break_normal / list_dps_break.Count()).ToString();
            label_dps_break_fs.Text = (breakdown_dps_break_fs / list_dps_break.Count()).ToString();
            label_dps_break_s1.Text = (breakdown_dps_break_s1 / list_dps_break.Count()).ToString();
            label_dps_break_s2.Text = (breakdown_dps_break_s2 / list_dps_break.Count()).ToString();
            label_dps_break_s3.Text = (breakdown_dps_break_s3 / list_dps_break.Count()).ToString();
            label_dps_break_buff.Text = (breakdown_dps_break_buff / list_dps_break.Count()).ToString();

            label_dps_lowest.Text = dps_lowest.ToString();
            label_dps_highest.Text = dps_highest.ToString();

            double real_crt_rate = attacks_crt / (double)attacks;

            double percent_od = frames_od / (double)frames_to_simulate;
            double percent_break = frames_break / (double)frames_to_simulate;
            if (battle_success)
            {
                percent_od = frames_od / (double)frames_taken;
                percent_break = frames_break / (double)frames_taken;
            }

            double time_clear = frames_taken / 60f;

            double time_od = percent_od * battle_length;
            double time_break = percent_break * battle_length;
            if (battle_success)
            {
                time_od = percent_od * time_clear;
                time_break = percent_break * time_clear;
            }

            int minutes_clear = (int)Math.Floor(time_clear) / 60;
            int minutes_od = (int)Math.Floor(time_od) / 60;
            int minutes_break = (int)Math.Floor(time_break) / 60;

            double seconds_clear = time_clear % 60;
            double seconds_od = time_od % 60;
            double seconds_break = time_break % 60;

            bool pad_seconds_clear = false;
            bool pad_seconds_od = false;
            bool pad_seconds_break = false;

            if (seconds_clear < 10)
            {
                pad_seconds_clear = true;
            }
            if (seconds_od < 10)
            {
                pad_seconds_od = true;
            }
            if (seconds_break < 10)
            {
                pad_seconds_break = true;
            }

            // formatting time
            if (enemy_hp <= 0)
            {
                label_clear_time.Text =
                    "--" + ":" +
                    "--.---";
            }
            else if (enemy_hp > 0 && !battle_success)
            {
                label_clear_time.Text =
                    "FAILED"; // quest timed out and not a sandbag
            }
            else if (pad_seconds_clear)
            {
                label_clear_time.Text =
                    minutes_clear.ToString() + ":" +
                    "0" + seconds_clear.ToString("N3");
            }
            else
            {
                label_clear_time.Text =
                    minutes_clear.ToString() + ":" +
                    seconds_clear.ToString("N3");
            }

            if (pad_seconds_od)
            {
                label_od_time.Text =
                    minutes_od.ToString() + ":" +
                    "0" + seconds_od.ToString("N3") +
                    " (" + (percent_od * 100).ToString("N2") + "%)";
            }
            else
            {
                label_od_time.Text =
                    minutes_od.ToString() + ":" +
                    seconds_od.ToString("N3") +
                    " (" + (percent_od * 100).ToString("N2") + "%)";
            }

            if (pad_seconds_break)
            {
                label_break_time.Text =
                    minutes_break.ToString() + ":" +
                    "0" + seconds_break.ToString("N3") +
                    " (" + (percent_break * 100).ToString("N2") + "%)";
            }
            else
            {
                label_break_time.Text =
                    minutes_break.ToString() + ":" +
                    seconds_break.ToString("N3") +
                    " (" + (percent_break * 100).ToString("N2") + "%)";
            }

            // attack stats (sanity check for crit rate)

            label_attack_stats.Text =
                attacks_crt.ToString() + " / " +
                attacks.ToString() + " (" +
                (real_crt_rate * 100).ToString("N2") + "%)";

            label_sim_state.Text = "Finished";
            progressBar_sim.Value = 100;

            SetInteractability(true);
        }

        void SetInteractability(bool option)
        {
            comboBox_dragon.Enabled = option;
            comboBox_pr1.Enabled = option;
            comboBox_pr2.Enabled = option;
            comboBox_enemy.Enabled = option;

            trackBar_dojo.Enabled = option;
            trackBar_altar.Enabled = option;
            trackBar_slime.Enabled = option;

            comboBox_coability_str.Enabled = option;
            comboBox_coability_sd.Enabled = option;
            comboBox_coability_crt_rate.Enabled = option;
            comboBox_coability_skill_haste.Enabled = option;

            checkBox_normal_attacks.Enabled = option;
            checkBox_fs.Enabled = option;
            checkBox_s1.Enabled = option;
            checkBox_s2.Enabled = option;
            checkBox_s3.Enabled = option;

            comboBox_attackCombo.Enabled = option;

            textBox_sim_count.Enabled = option;
            textBox_team_dps.Enabled = option;

            button_simulate.Enabled = option;
        }

        void GainSP(int sp)
        {
            counter_s1 += (int)Math.Ceiling(sp * ((100 + skill_haste) / 100f));
            counter_s2 += (int)Math.Ceiling(sp * ((100 + skill_haste) / 100f));
            counter_s3 += (int)Math.Ceiling(sp * ((100 + skill_haste) / 100f));

            if (counter_s1 > spcost_s1)
            {
                counter_s1 = spcost_s1;
            }
            if (counter_s2 > spcost_s2)
            {
                counter_s2 = spcost_s2;
            }
            if (counter_s3 > spcost_s3)
            {
                counter_s3 = spcost_s3;
            }
        }

        void ApplyDebuff(string tag)
        {
            string[] array = tag.Split(' ');
            // Type, Intensity, Duration, Chance in this order.

            int roll = 0;
            int chance = 0;
            int.TryParse(array[3], out chance);

            roll = rand.Next(100);

            if (!(roll < chance))
            {
                return; // failed proc
            }

            if (array[0] == "DefDown")
            {
                // Defense Down

                BuffObject dd = new BuffObject();
                int.TryParse(array[1], out dd.intensity);
                int.TryParse(array[2], out dd.frames);
                dd.frames = dd.frames * 60;
                dd.type = array[0];

                enemy_debuffs.Add(dd);
            }
        }

        int GetSumOfPlayerBuffs(string t)
        {
            int sum = 0;
            foreach (var s in player_buffs)
            {
                if (s.type == t)
                {
                    sum += s.intensity;
                }
                
            }
            return sum;
        }

        int GetSumOfEnemyDebuffs(string t)
        {
            int sum = 0;
            foreach (var s in enemy_debuffs)
            {
                if (s.type == t)
                {
                    sum += s.intensity;
                }
            }

            if (t == "DefDown" && sum > enemy_def_debuff_cap)
            {
                sum = enemy_def_debuff_cap;
            }
            return sum;
        }

        double GetModifiedDefense(double enemy_def_debuff)
        {
            if (enemy_def_debuff > enemy_def_debuff_cap)
                enemy_def_debuff = enemy_def_debuff_cap;

            return enemy_def * ((100 - enemy_def_debuff) / 100f);
        }

        int Damage(int dmg, int buff, double enemy_def_debuff, bool is_skill = false, bool is_fs = false)
        {
            attacks++;

            double coability_str_mod = (100 + coability_str) / 100f;
            double coability_sd_mod = (100 + coability_sd) / 100f;

            int effective_str = (int)Math.Ceiling((displ_str * coability_str_mod) + (int)Math.Ceiling(displ_str * (buff / 100f)));

            bool crt_proc = false;
            int crt_roll = rand.Next(100);

            if (crt_roll < crt_rate)
            {
                crt_proc = true;
                attacks_crt++;
            }
                

            int sd_modifier = sd_mult;
            if (!is_skill)
            {
                sd_modifier = 0;
                coability_str_mod = 1;
            } 

            int fs_modifier = fs_mult;
            if (!is_fs)
                fs_modifier = 0;

            double actual_sd_mult = ((100 + sd_modifier) / 100f) * coability_sd_mod;
            double actual_fs_mult = (100 + fs_modifier) / 100f;

            int crt_modifier = crt_mod;
            if (!crt_proc)
                crt_modifier = 0;

            double actual_crt_mod = (100 + crt_modifier) / 100f;

            double real_break_def_mod = enemy_break_def_mod;
            if (enemy_state != 2)
            {
                // enemy not broken
                real_break_def_mod = 1;
            }

            double enemy_real_def = GetModifiedDefense(enemy_def_debuff) * real_break_def_mod;

            double effective_ele_bonus = 1.5f;

            double real_dmg = dmg / 100f;

            double actual_damage = 5 * 
                (effective_str *
                real_dmg * 
                actual_sd_mult * 
                actual_fs_mult * 
                actual_crt_mod * 
                effective_ele_bonus)
                / enemy_real_def
                / 3f;
            
            // debug - removes all abilities
            /*double actual_damage = 5 *
                (effective_str *
                real_dmg *
                1 *
                1 *
                1 *
                effective_ele_bonus)
                / enemy_real_def
                / 3f;*/

            int actual_damage_int = (int)Math.Floor(actual_damage);
            if (actual_damage_int < 1)
                actual_damage_int = 1;

            // apply the damage number to the enemy
            if (enemy_current_hp > 0)
            {
                enemy_current_hp -= actual_damage_int;

                if (enemy_current_hp <= 0)
                {
                    // we beat the enemy!
                    battle_success = true;
                }
            }

            if (enemy_state == 0)
            {
                // neither od nor break, fill od gauge
                enemy_current_od_buildup -= actual_damage_int;

                if (enemy_current_od_buildup <= 0)
                {
                    // od start
                    enemy_state = 1;
                }
            }
            else if (enemy_state == 1)
            {
                // enemy in od
                double real_fs_odmult = fs_odmult;
                if (!is_fs)
                    real_fs_odmult = 1;

                enemy_current_od_hp -= (int)Math.Floor(actual_damage_int * real_fs_odmult);

                if (enemy_current_od_hp <= 0)
                {
                    // break start
                    enemy_state = 2;
                    frames_break_remaining = total_enemy_break_frames;
                }
            }

            return actual_damage_int;
        }
        private int UseSkill(int frame_data, int[] damage_data, string tags, int skill_num)
        {
            double skill_frame_interval = frame_data / (double)(damage_data.Length + 1);
            int segment = 0; // incremented in the foreach
            foreach (int skill_dmg in damage_data)
            {
                segment++;
                DamageObject dmg_obj = new DamageObject();

                dmg_obj.dmg = skill_dmg;
                dmg_obj.frames = (int)Math.Floor(skill_frame_interval * segment);
                dmg_obj.type = "s" + skill_num.ToString();

                if (segment == 1)
                {
                    dmg_obj.tag = tags; // apply only on first hit. applies to most skills with effect, but some won't - do it later
                }
                else
                {
                    dmg_obj.tag = "";
                }

                queued_attacks.Add(dmg_obj);


                // commented old code for reference
                /*int sd = Damage(skill_dmg, str_buff, enemy_def_debuff, true, false);
                result.dmg_s1 += sd;
                if (enemy_state == 1)
                {
                    result_od.dmg_s1 += sd;
                }*/
            }
            return frame_data; // needed to stop the adventurer from attacking for the duration of the skill
        }

        private void textBox_sim_count_TextChanged(object sender, EventArgs e)
        {
            int cnt = 1;
            int.TryParse(textBox_sim_count.Text, out cnt);
            if (cnt < 1)
                cnt = 1;
            else if (cnt > 10000)
                cnt = 10000; // For performance reasons, do not allow user to set it past 10000
            sim_count = cnt;
            textBox_sim_count.Text = sim_count.ToString();
        }

        private void textBox_team_dps_TextChanged(object sender, EventArgs e)
        {
            int tdps = 1;
            int.TryParse(textBox_team_dps.Text, out tdps);
            if (tdps < 0)
                tdps = 0;
            team_dps = tdps;
        }

        private void comboBox_pr1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // todo; move these data to a different part to keep this clean
            // instead of a switch, might call an external function
            // also lets pr2 reuse code
            switch (comboBox_pr1.Text)
            {
                case "Resounding Rendition":
                    pr1_hp = 177;
                    pr1_str = 64;

                    ability_sd_pr1 = 30;
                    ability_fs_pr1 = 0;

                    ability_hp_pr1 = 0;
                    ability_str_pr1 = 0;

                    ability_crt_rate_pr1 = 8;
                    ability_crt_mod_pr1 = 0;

                    ability_skill_haste_pr1 = 0;
                    break;
                case "The Shining Overlord":
                    pr1_hp = 176;
                    pr1_str = 65;

                    ability_sd_pr1 = 40;
                    ability_fs_pr1 = 0;

                    ability_hp_pr1 = 0;
                    ability_str_pr1 = 0;

                    ability_crt_rate_pr1 = 0;
                    ability_crt_mod_pr1 = 0;

                    ability_skill_haste_pr1 = 0;
                    break;
                case "Heralds of Hinomoto":
                    pr1_hp = 177;
                    pr1_str = 64;

                    ability_sd_pr1 = 30;
                    ability_fs_pr1 = 0;

                    ability_hp_pr1 = 0;
                    ability_str_pr1 = 0;

                    ability_crt_rate_pr1 = 0;
                    ability_crt_mod_pr1 = 0;

                    ability_skill_haste_pr1 = 6;
                    break;
                case "Plunder Pals":
                    pr1_hp = 151;
                    pr1_str = 54;

                    ability_sd_pr1 = 30;
                    ability_fs_pr1 = 0;

                    ability_hp_pr1 = 0;
                    ability_str_pr1 = 0;

                    ability_crt_rate_pr1 = 0;
                    ability_crt_mod_pr1 = 0;

                    ability_skill_haste_pr1 = 0;
                    break;
                default:
                    pr1_hp = 0;
                    pr1_str = 0;

                    ability_sd_pr1 = 0;
                    ability_fs_pr1 = 0;

                    ability_hp_pr1 = 0;
                    ability_str_pr1 = 0;

                    ability_crt_rate_pr1 = 0;
                    ability_crt_mod_pr1 = 0;

                    ability_skill_haste_pr1 = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_pr2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // todo; move these data to a different part to keep this clean
            // instead of a switch, might call an external function
            // also lets pr1 reuse code
            switch (comboBox_pr2.Text)
            {
                case "Fresh Perspective":
                    pr2_hp = 140;
                    pr2_str = 52;

                    ability_sd_pr2 = 20;
                    ability_fs_pr2 = 40;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 0;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 0;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "Levin's Champion":
                    pr2_hp = 176;
                    pr2_str = 64;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 0;

                    ability_crt_rate_pr2 = 10;
                    ability_crt_mod_pr2 = 15;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "Stellar Show":
                    pr2_hp = 176;
                    pr2_str = 65;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 50;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 0;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 15;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "Seaside Princess":
                    pr2_hp = 176;
                    pr2_str = 65;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 15;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 22;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "Evening of Luxury":
                    pr2_hp = 176;
                    pr2_str = 65;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 15;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 15;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "Jewels of the Sun":
                    pr2_hp = 176;
                    pr2_str = 64;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 10;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 0;

                    ability_skill_haste_pr2 = 8;
                    break;
                case "Beautiful Nothingness":
                    pr2_hp = 141;
                    pr2_str = 51;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 10;

                    ability_crt_rate_pr2 = 5;
                    ability_crt_mod_pr2 = 0;

                    ability_skill_haste_pr2 = 0;
                    break;
                case "United by One Vision":
                    pr2_hp = 150;
                    pr2_str = 54;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 13;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 0;

                    ability_skill_haste_pr2 = 8;
                    break;
                default:
                    pr2_hp = 0;
                    pr2_str = 0;

                    ability_sd_pr2 = 0;
                    ability_fs_pr2 = 0;

                    ability_hp_pr2 = 0;
                    ability_str_pr2 = 0;

                    ability_crt_rate_pr2 = 0;
                    ability_crt_mod_pr2 = 0;

                    ability_skill_haste_pr2 = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_attackCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_attackCombo.Text)
            {
                case "C5":
                    max_permitted_chain_length = 5;
                    break;
                case "C4":
                    max_permitted_chain_length = 4;
                    break;
                case "C3":
                    max_permitted_chain_length = 3;
                    break;
                case "C2":
                    max_permitted_chain_length = 2;
                    break;
                case "C1":
                    max_permitted_chain_length = 1;
                    break;
                default:
                    max_permitted_chain_length = 5;
                    break;
            }
        }

        private void checkBox_fs_CheckedChanged(object sender, EventArgs e)
        {
            enable_fs = checkBox_fs.Checked;

            if (!enable_fs)
                checkBox_normal_attacks.Enabled = false;
            else
                checkBox_normal_attacks.Enabled = true;
        }

        private void checkBox_normal_attacks_CheckedChanged(object sender, EventArgs e)
        {
            enable_normal_attacks = checkBox_normal_attacks.Checked;

            if (!enable_normal_attacks)
                checkBox_fs.Enabled = false;
            else
                checkBox_fs.Enabled = true;
        }

        private void checkBox_s1_CheckedChanged(object sender, EventArgs e)
        {
            enable_s1 = checkBox_s1.Checked;
        }

        private void checkBox_s2_CheckedChanged(object sender, EventArgs e)
        {
            enable_s2 = checkBox_s2.Checked;
        }

        private void checkBox_s3_CheckedChanged(object sender, EventArgs e)
        {
            enable_s3 = checkBox_s3.Checked;
        }

        private void comboBox_enemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_enemy.Text)
            {
                case "Sandbag (60 seconds)":
                    battle_length = 60;

                    enemy_hp = 0;
                    enemy_od_start = 16667;
                    enemy_od_hp = 50000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Sandbag (120 seconds)":
                    battle_length = 120;

                    enemy_hp = 0;
                    enemy_od_start = 33333;
                    enemy_od_hp = 100000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Sandbag (180 seconds)":
                    battle_length = 180;

                    enemy_hp = 0;
                    enemy_od_start = 50000;
                    enemy_od_hp = 150000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Sandbag (240 seconds)":
                    battle_length = 240;

                    enemy_hp = 0;
                    enemy_od_start = 66667;
                    enemy_od_hp = 200000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Sandbag (300 seconds)":
                    battle_length = 300;

                    enemy_hp = 0;
                    enemy_od_start = 83333;
                    enemy_od_hp = 250000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Sandbag (600 seconds)":
                    battle_length = 600;

                    enemy_hp = 0;
                    enemy_od_start = 166667;
                    enemy_od_hp = 500000;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Void Zephyr":
                    battle_length = 240;

                    enemy_hp = 407680;
                    enemy_od_start = 61152;
                    enemy_od_hp = 101920;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "High Midgardsormr":
                    battle_length = 300;

                    enemy_hp = 863164;
                    enemy_od_start = 258949;
                    enemy_od_hp = 172632;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 55;
                    break;
                case "High Midgardsormr (Prelude)":
                    battle_length = 300;

                    enemy_hp = 497182;
                    enemy_od_start = 99436;
                    enemy_od_hp = 74577;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 55;
                    break;
                case "Fafnir Roy III (Wind, Lv 20)":
                    battle_length = 60;

                    enemy_hp = 286348;
                    enemy_od_start = 45194;
                    enemy_od_hp = 114539;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Fafnir Roy III (Wind, Lv 40)":
                    battle_length = 60;

                    enemy_hp = 625279;
                    enemy_od_start = 95832;
                    enemy_od_hp = 250112;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                case "Fafnir Roy III (Wind, Lv 50)":
                    battle_length = 120;

                    enemy_hp = 2081385;
                    enemy_od_start = 312209;
                    enemy_od_hp = 520346;

                    enemy_def = 10;

                    enemy_break_duration = 10;
                    enemy_break_def_mod = 0.6;

                    enemy_res_burn = 0;
                    break;
                default:
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_coability_str_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox_coability_str.Text)
            {
                case "+1%":
                    coability_str = 1;
                    break;
                case "+3%":
                    coability_str = 3;
                    break;
                case "+4%":
                    coability_str = 4;
                    break;
                case "+5%":
                    coability_str = 5;
                    break;
                case "+6%":
                    coability_str = 6;
                    break;
                case "+7%":
                    coability_str = 7;
                    break;
                case "+8%":
                    coability_str = 8;
                    break;
                case "+10%":
                    coability_str = 10;
                    break;
                default:
                    coability_str = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_coability_crt_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_coability_crt_rate.Text)
            {
                case "+1%":
                    coability_crt_rate = 1;
                    break;
                case "+3%":
                    coability_crt_rate = 3;
                    break;
                case "+4%":
                    coability_crt_rate = 4;
                    break;
                case "+5%":
                    coability_crt_rate = 5;
                    break;
                case "+6%":
                    coability_crt_rate = 6;
                    break;
                case "+7%":
                    coability_crt_rate = 7;
                    break;
                case "+8%":
                    coability_crt_rate = 8;
                    break;
                case "+10%":
                    coability_crt_rate = 10;
                    break;
                default:
                    coability_crt_rate = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_coability_sd_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_coability_sd.Text)
            {
                case "+2%":
                    coability_sd = 2;
                    break;
                case "+5%":
                    coability_sd = 5;
                    break;
                case "+6%":
                    coability_sd = 6;
                    break;
                case "+8%":
                    coability_sd = 8;
                    break;
                case "+9%":
                    coability_sd = 9;
                    break;
                case "+11%":
                    coability_sd = 11;
                    break;
                case "+12%":
                    coability_sd = 12;
                    break;
                case "+15%":
                    coability_sd = 15;
                    break;
                default:
                    coability_sd = 0;
                    break;
            }

            CalculateDisplayedStat();
        }

        private void comboBox_coability_skill_haste_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_coability_skill_haste.Text)
            {
                case "+2%":
                    coability_skill_haste = 2;
                    break;
                case "+5%":
                    coability_skill_haste = 5;
                    break;
                case "+6%":
                    coability_skill_haste = 6;
                    break;
                case "+8%":
                    coability_skill_haste = 8;
                    break;
                case "+9%":
                    coability_skill_haste = 9;
                    break;
                case "+11%":
                    coability_skill_haste = 11;
                    break;
                case "+12%":
                    coability_skill_haste = 12;
                    break;
                case "+15%":
                    coability_skill_haste = 15;
                    break;
                default:
                    coability_skill_haste = 0;
                    break;
            }

            CalculateDisplayedStat();
        }
    }
}
